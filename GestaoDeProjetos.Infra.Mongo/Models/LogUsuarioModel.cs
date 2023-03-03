using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Infra.Mongo.Models
{
    public class LogUsuarioModel
    {
        public Guid? Id { get; set; }
        public string? Operacao { get; set; }
        public string? Detalhes { get; set; }
        public DateTime? DataHora { get; set; }
        public Guid? UsuarioId { get; set; }
    }
}
