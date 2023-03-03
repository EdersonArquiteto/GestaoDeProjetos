using GestaoDeProjetos.Application.Commands;
using GestaoDeProjetos.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProjetos.API.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public AuthController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public IActionResult Login(AutenticarUsuarioCommand command)
        {
            var model = _usuarioAppService.AutenticarUsuario(command);

            return StatusCode(200, new
            {
                message = "Usuário autenticado com sucesso.",
                model
            });
        }
    }
}
