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
    public class Tarefa : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHoraConclusao{ get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public Usuario Responsavel { get; set; }
        public Guid IdUsuario { get; set; }
        public StatusTarefa Status { get; set; }

        public Projeto Projeto { get; set; }
        public Guid IdProjeto { get; set; }
        public ValidationResult Validate => new TarefaValidation().Validate(this);
    }
}
