using GestaoDeProjetos.Application.Commands;
using GestaoDeProjetos.Domain.Models;
using GestaoDeProjetos.Infra.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        /// <summary>
        /// Método para criar um usuário na aplicação
        /// </summary>
        /// <param name="command">Dados para criação do usuário</param>
        Task CriarUsuario(CriarUsuarioCommand command);

        Task<AuthorizationModel> AutenticarUsuario(AutenticarUsuarioCommand command);

        List<LogUsuarioModel> ConsultarLogDeUsuario(string email);

    }
}
