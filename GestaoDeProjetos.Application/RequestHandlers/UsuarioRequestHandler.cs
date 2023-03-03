using AutoMapper;
using FluentValidation;
using GestaoDeProjetos.Application.Commands;
using GestaoDeProjetos.Application.Notifications;
using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.Services;
using GestaoDeProjetos.Domain.Models;
using GestaoDeProjetos.Infra.Messages.Models;
using GestaoDeProjetos.Infra.Messages.Producers;
using GestaoDeProjetos.Infra.Messages.ValueObjects;
using GestaoDeProjetos.Infra.Mongo.Models;
using MediatR;
using Newtonsoft.Json;

namespace GestaoDeProjetos.Application.RequestHandlers
{
    public class UsuarioRequestHandler :
        IRequestHandler<CriarUsuarioCommand>,
        IRequestHandler<AutenticarUsuarioCommand, AuthorizationModel>,
        IDisposable
    {
        //atributos
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly MessageQueueProducer _messageQueueProducer;
        private readonly IMediator _mediatR;
        private readonly IMapper _mapper;
        

        //construtor para injeções de dependência
        public UsuarioRequestHandler(IUsuarioDomainService usuarioDomainService, MessageQueueProducer messageQueueProducer, IMediator mediatR, IMapper mapper)
        {
            _usuarioDomainService = usuarioDomainService;
            _messageQueueProducer = messageQueueProducer;
            _mediatR = mediatR;
            _mapper = mapper;
           
        }

        /// <summary>
        /// Implementar o fluxo CQRS para criação de usuário
        /// </summary>
        public async Task<Unit> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            #region Capturando e validando o usuário

            var usuario = _mapper.Map<Usuario>(request);

            var validate = usuario.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            #endregion

            #region Cadastrando o usuário

            _usuarioDomainService.CriarUsuario(usuario);

            #endregion

            #region Enviando uma mensagem para a fila

            var _messageQueueModel = new MessageQueueModel
            {
                Tipo = TipoMensagem.CONFIRMACAO_DE_CADASTRO,
                Conteudo = JsonConvert.SerializeObject(new UsuariosMessageVO
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                })
            };

            //var response = await _service.PostAsync("/CriacaoDeUsuario", Conteudo);
            _messageQueueProducer.Create(_messageQueueModel);

            #endregion

            #region Gravando o log da operação

            var logUsuariosNotification = new LogUsuariosNotification
            {
                LogUsuario = new LogUsuarioModel
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = usuario.Id,
                    DataHora = DateTime.Now,
                    Operacao = "Criação de usuário",
                    Detalhes = JsonConvert.SerializeObject(new { usuario.Nome, usuario.Email })
                }
            };

            await _mediatR.Publish(logUsuariosNotification);

            #endregion

            return Unit.Value;
        }

        /// <summary>
        /// Implementar o fluxo CQRS para autenticação de usuário
        /// </summary>
        public async Task<AuthorizationModel> Handle(AutenticarUsuarioCommand request, CancellationToken cancellationToken)
        {
            #region Autenticando o usuário

            var model = _usuarioDomainService.AutenticarUsuario(request.Email, request.Senha);

            #endregion

            #region Gravando o log da operação

            var logUsuariosNotification = new LogUsuariosNotification
            {
                LogUsuario = new LogUsuarioModel
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = model.Id,
                    DataHora = DateTime.Now,
                    Operacao = "Autenticação de usuário",
                    Detalhes = JsonConvert.SerializeObject(new { model.Nome, model.Email })
                }
            };

            await _mediatR.Publish(logUsuariosNotification);

            #endregion

            return model;
        }

        public void Dispose()
        {
            _usuarioDomainService.Dispose();
        }
    }

    /// <summary>
    /// Classe auxiliar para deserializar a resposta obtida da API
    /// </summary>
    public class ResultContent
    {
        public string? Message { get; set; }
    }
}
