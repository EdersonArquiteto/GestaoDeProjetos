using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.Repositories;
using GestaoDeProjetos.Infra.SQL.Contexts;

namespace GestaoDeProjetos.Infra.SQL.Repositories
{
    public class ProjetoRepository : BaseRepository<Projeto, Guid>, IProjetoRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        
        public ProjetoRepository(SqlServerContext sqlServerContext)
            : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public Projeto GetByTitulo(string titulo)
        {
            return _sqlServerContext.Projeto
                 .FirstOrDefault(p => p.Titulo.Equals(titulo));
        }
    }
}
