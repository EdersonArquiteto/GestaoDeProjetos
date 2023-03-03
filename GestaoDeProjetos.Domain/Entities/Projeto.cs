using FluentValidation.Results;
using GestaoDeProjetos.Domain.Core;
using GestaoDeProjetos.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Domain.Entities
{
    public class Projeto : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHoraCriacao { get; set; }

        public ValidationResult Validate => new ProjetoValidation().Validate(this);
    }
}
