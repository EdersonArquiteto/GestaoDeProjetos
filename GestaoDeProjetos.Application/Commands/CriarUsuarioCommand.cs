using MediatR;

namespace GestaoDeProjetos.Application.Commands
{
    public class CriarUsuarioCommand : IRequest
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
