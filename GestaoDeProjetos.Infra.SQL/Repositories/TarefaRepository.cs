using GestaoDeProjetos.Domain.Core;
using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.Repositories;
using GestaoDeProjetos.Infra.SQL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Infra.SQL.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa, Guid>, ITarefaRepository
    {
        private readonly SqlServerContext _sqlServerContext;


        public TarefaRepository(SqlServerContext sqlServerContext)
            : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public List<Tarefa> GetByResponsavel(Usuario responsavel)
        {
            var tarefas= _sqlServerContext.Tarefa.ToList().Where(t=>t.Responsavel== responsavel);
            return tarefas.ToList();
        }

        public Tarefa GetByTitulo(string titulo)
        {
            return _sqlServerContext.Tarefa
               .FirstOrDefault(t => t.Titulo.Equals(titulo));
        }

       
    }
}
