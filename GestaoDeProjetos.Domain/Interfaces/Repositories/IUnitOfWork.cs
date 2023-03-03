using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        IUsuarioRepository UsuarioRepository { get; }
        IProjetoRepository ProjetoRepository { get; }
        ITarefaRepository TarefaRepository { get; }
    }
}
