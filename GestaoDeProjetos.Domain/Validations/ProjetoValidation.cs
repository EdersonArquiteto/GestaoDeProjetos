using FluentValidation;
using GestaoDeProjetos.Domain.Entities;

namespace GestaoDeProjetos.Domain.Validations
{
    public class ProjetoValidation : AbstractValidator<Projeto>
    {
        public ProjetoValidation()
        {
            RuleFor(u => u.Id)
                .NotEmpty()
                .WithMessage("Id é obrigatório.");

            RuleFor(u => u.Titulo)
                .NotEmpty()
                .Length(6, 150)
                .WithMessage("Nome de Projeto inválido.");

            RuleFor(u => u.Descricao)
                .NotEmpty()
                .WithMessage("A descricao do projeto não pode está em branco.");

            
        }
    }
}
