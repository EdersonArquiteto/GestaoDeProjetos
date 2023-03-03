using GestaoDeProjetos.Application.Commands;
using GestaoDeProjetos.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProjetos.API.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(CriarUsuarioCommand command)
        {
            await _usuarioAppService.CriarUsuario(command);

            return StatusCode(201, new
            {
                message = "Usuário cadastrado com sucesso.",
                command
            });
        }
    }
}
