using GestaoDeProjetos.Domain.Entities;

namespace GestaoDeProjetos.Application.Commands
{
    public class CriarTarefaCommand
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHoraConclusao { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public Usuario Responsavel { get; set; }
        public StatusTarefa Status { get; set; }
        public Projeto Projeto { get; set; }
       
    }
}
