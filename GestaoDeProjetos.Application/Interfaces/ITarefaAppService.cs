using GestaoDeProjetos.Application.Commands;
using GestaoDeProjetos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Application.Interfaces
{
    public interface ITarefaAppService
    {
        
        Tarefa GetByTitulo(string titulo);
        public List<Tarefa> GetByResponsavel(Usuario responsavel);
        public void UpdateTarefa(Tarefa tarefa);
        Task CriarTarefa(CriarTarefaCommand command);
    }
}
