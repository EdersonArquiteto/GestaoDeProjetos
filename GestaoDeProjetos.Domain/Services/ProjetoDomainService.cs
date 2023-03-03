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
    public class ProjetoDomainService : IProjetoDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjetoDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CriarProjeto(Projeto projeto)
        {
            //Não é permitido cadastrar Projetos com o mesmo título
            DomainException.When(
                    _unitOfWork.ProjetoRepository.GetByTitulo(projeto.Titulo) != null,
                    $"O projeto {projeto.Titulo} já está cadastrado, tente outro."
                );

            _unitOfWork.ProjetoRepository.Create(projeto);
        }
        public List<Projeto> ListarProjeto()
        {
          return _unitOfWork.ProjetoRepository.GetAll();
        }

        public void Dispose()
        {
            _unitOfWork?.UsuarioRepository.Dispose();
        }
    }
}
