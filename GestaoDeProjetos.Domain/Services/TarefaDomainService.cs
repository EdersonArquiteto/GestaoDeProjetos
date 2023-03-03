using GestaoDeProjetos.Domain.Core;
using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.Repositories;
using GestaoDeProjetos.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Domain.Services
{
    public class TarefaDomainService : ITarefaDomainService 
    {
        private readonly IUnitOfWork _unitOfWork;

        public TarefaDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CriarTarefa(Tarefa tarefa)
        {
            //Não é permitido cadastrar usuários com o mesmo email
            DomainException.When(
                    _unitOfWork.TarefaRepository.GetByTitulo(tarefa.Titulo) != null,
                    $"A tarefa {tarefa.Titulo} já está cadastrada, tente outro título."
                );

            _unitOfWork.TarefaRepository.Create(tarefa);
        }

        public List<Tarefa> GetByResponsavel(Usuario responsavel)
        {
            return _unitOfWork.TarefaRepository.GetByResponsavel(responsavel);
        }

        public Tarefa GetByTitulo(string titulo)
        {
            return _unitOfWork.TarefaRepository.GetByTitulo(titulo);
        }

        public void UpdateTarefa(Tarefa tarefa)
        {
            _unitOfWork.TarefaRepository.Update(tarefa);
        }
        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
