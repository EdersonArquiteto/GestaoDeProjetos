using AutoMapper;
using FluentValidation;
using GestaoDeProjetos.Application.Commands;
using GestaoDeProjetos.Application.Interfaces;
using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.Services;
using GestaoDeProjetos.Domain.Services;
using GestaoDeProjetos.Infra.Messages.Models;
using GestaoDeProjetos.Infra.Messages.Producers;
using GestaoDeProjetos.Infra.Messages.ValueObjects;
using GestaoDeProjetos.Infra.Messages.VO;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Application.Services
{
    public class TarefaAppService : ITarefaAppService
    {
        private readonly ITarefaDomainService _tarefaDomainService;
        private readonly IMapper _mapper;
        private readonly MessageQueueProducer _messageQueueProducer;

        public TarefaAppService(ITarefaDomainService tarefaDomainService, IMapper mapper, MessageQueueProducer messageQueueProducer)
        {
            _tarefaDomainService = tarefaDomainService;
            _mapper = mapper;
            _messageQueueProducer = messageQueueProducer;
        }

        public Task CriarTarefa(CriarTarefaCommand command)
        {
            #region Capturando e validando a tarefa

            var t = _mapper.Map<Tarefa>(command);

            var validate = t.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            #endregion

            #region Cadastrando a tarefa

            _tarefaDomainService.CriarTarefa(t);

            #endregion

            #region Enviando uma mensagem para a fila

            var _messageQueueModel = new MessageQueueModel
            {
                Tipo = TipoMensagem.CADASTRO_DE_TAREFA,
                Conteudo = JsonConvert.SerializeObject(new TarefaMessageVO
                {
                    Id = command.Id,
                    Titulo = command.Titulo,
                    Descricao = command.Descricao,
                    DataHoraCriacao = command.DataHoraCriacao,
                    DataHoraConclusao = command.DataHoraConclusao
                })
            };


            _messageQueueProducer.Create(_messageQueueModel);
            return Task.CompletedTask;
            #endregion
        }

        public List<Tarefa> GetByResponsavel(Usuario responsavel)
        {
            throw new NotImplementedException();
        }

        public Tarefa GetByTitulo(string titulo)
        {
            throw new NotImplementedException();
        }

        public void UpdateTarefa(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }
    }
}
