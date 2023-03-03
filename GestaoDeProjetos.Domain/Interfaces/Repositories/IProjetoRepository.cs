using GestaoDeProjetos.Domain.Core;
using GestaoDeProjetos.Domain.Entities;

namespace GestaoDeProjetos.Domain.Interfaces.Repositories
{
    public interface IProjetoRepository : IBaseRepository<Projeto, Guid>
    {
        
        Projeto GetByTitulo(string titulo);

    }
}
