using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService : IDisposable
    {
        /// <summary>
        /// Método para criar um usuário na aplicação
        /// </summary>
        /// <param name="usuario">Entidade de domínio</param>
        void CriarUsuario(Usuario usuario);
        AuthorizationModel AutenticarUsuario(string email, string senha);

    }
}
