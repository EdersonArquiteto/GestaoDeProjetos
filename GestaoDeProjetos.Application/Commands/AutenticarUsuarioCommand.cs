using GestaoDeProjetos.Domain.Models;
using MediatR;

namespace GestaoDeProjetos.Application.Commands
{
    public class AutenticarUsuarioCommand : IRequest<AuthorizationModel>
    {
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
