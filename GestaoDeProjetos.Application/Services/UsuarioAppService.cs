using GestaoDeProjetos.Application.Commands;
using GestaoDeProjetos.Application.Interfaces;
using GestaoDeProjetos.Domain.Models;
using GestaoDeProjetos.Infra.Mongo.Interfaces;
using GestaoDeProjetos.Infra.Mongo.Models;
using MediatR;

namespace GestaoDeProjetos.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        //atributos
        private readonly IMediator _mediatR;
        private readonly ILogUsuariosPersistence _logUsuariosPersistence;

        //construtor para injeção de dependência
        public UsuarioAppService(IMediator mediatR, ILogUsuariosPersistence logUsuariosPersistence)
        {
            _mediatR = mediatR;
            _logUsuariosPersistence = logUsuariosPersistence;
        }

        public async Task CriarUsuario(CriarUsuarioCommand command)
        {
            await _mediatR.Send(command);
        }

        public async Task<AuthorizationModel> AutenticarUsuario(AutenticarUsuarioCommand command)
        {
            return await _mediatR.Send(command);
        }

        public List<LogUsuarioModel> ConsultarLogDeUsuario(string email)
        {
            return _logUsuariosPersistence.GetAll(email);
        }
    }
}
