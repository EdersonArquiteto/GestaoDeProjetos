using GestaoDeProjetos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Domain.Interfaces.Services
{
    public interface ITarefaDomainService : IDisposable
    {
        public void CriarTarefa(Tarefa tarefa);
        Tarefa GetByTitulo(string titulo);
        public List<Tarefa> GetByResponsavel(Usuario responsavel);
        public void UpdateTarefa(Tarefa tarefa);
    }
}
