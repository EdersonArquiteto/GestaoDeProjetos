using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Application.Commands
{
    public class ListarProjetoQuery
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHoraCriacao { get; set; }
    }
}
