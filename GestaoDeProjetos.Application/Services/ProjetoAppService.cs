using AutoMapper;
using FluentValidation;
using GestaoDeProjetos.Application.Commands;
using GestaoDeProjetos.Application.Interfaces;
using GestaoDeProjetos.Application.Notifications;
using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.Services;
using GestaoDeProjetos.Domain.Models;
using GestaoDeProjetos.Infra.Messages.Producers;
using GestaoDeProjetos.Infra.Mongo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Application.Services
{
    public class ProjetoAppService : IProjetoAppService
    {
        private readonly IProjetoDomainService _projetoDomainService;
        private readonly IMapper _mapper;

        public ProjetoAppService(IProjetoDomainService projetoDomainService, IMapper mapper)
        {
            _projetoDomainService = projetoDomainService;
            _mapper = mapper;
        }

        public async Task CriarProjeto(CriarProjetoCommand command)
        {
            #region Capturando e validando o Projeto

            var projeto = _mapper.Map<Projeto>(command);

            var validate = projeto.Validate;
            if (!validate.IsValid)
                throw new ValidationException(validate.Errors);

            #endregion

            #region Cadastrando o projeto

                _projetoDomainService.CriarProjeto(projeto);
            #endregion
        }

        public  List<ListarProjetoQuery> ListarProjetos()
        {
            return _mapper.Map<List<ListarProjetoQuery>>(_projetoDomainService.ListarProjeto()); 
        }
    }
}
