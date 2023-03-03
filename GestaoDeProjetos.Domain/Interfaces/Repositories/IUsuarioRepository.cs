using GestaoDeProjetos.Domain.Core;
using GestaoDeProjetos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, Guid>
    {
        /// <summary>
        /// Método para consultar 1 usuário baseado no email
        /// </summary>
        Usuario GetByEmail(string email);

        /// <summary>
        /// Método para consultar 1 usuário baseado no email e senha
        /// </summary>
        Usuario GetByEmailAndSenha(string email, string senha);
    }
}
