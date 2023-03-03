using GestaoDeProjetos.Domain.Core;
using GestaoDeProjetos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository : IBaseRepository<Tarefa, Guid>
    {
        Tarefa GetByTitulo(string titulo);
        public List<Tarefa> GetByResponsavel(Usuario responsavel);
        
    }
}
