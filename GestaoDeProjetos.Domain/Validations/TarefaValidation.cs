using FluentValidation;
using GestaoDeProjetos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Domain.Validations
{
    public class TarefaValidation : AbstractValidator<Tarefa>
    {
        public TarefaValidation()
        {
            RuleFor(t => t.Id)
                .NotEmpty()
                .WithMessage("Id é obrigatório.");

            RuleFor(t => t.Titulo)
                .NotEmpty()
                .Length(6, 150)
                .WithMessage("O título da tarefa é inválido.");

            RuleFor(t => t.Descricao)
                .NotEmpty()
                .WithMessage("A Descrição da tarefa é inválida.");

            RuleFor(t => t.DataHoraCriacao)
                 .NotEmpty()
                 .WithMessage("Data de Criação da tarefa é inválida.");

            RuleFor(t => t.DataHoraConclusao)
                 .NotEmpty()
                 .WithMessage("Data de Conclusão da tarefa é inválida.");
            RuleFor(t => t.Responsavel)
                 .NotEmpty()
                 .WithMessage("Responsavel pela Conclusão da tarefa é inválido.");
            RuleFor(t => t.Responsavel)
                .NotEmpty()
                .WithMessage("Responsavel pela Conclusão da tarefa é inválido.");
            RuleFor(t => t.Status)
                .NotEmpty()
                .WithMessage("O status da tarefa é inválido.");

        }
    }
}
