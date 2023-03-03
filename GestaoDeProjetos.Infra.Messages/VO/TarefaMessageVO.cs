using GestaoDeProjetos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Infra.Messages.VO
{
    public class TarefaMessageVO
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHoraConclusao { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public Usuario Responsavel { get; set; }
    }
}
