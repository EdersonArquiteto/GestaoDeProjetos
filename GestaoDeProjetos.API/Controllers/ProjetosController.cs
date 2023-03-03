using GestaoDeProjetos.Application.Commands;
using GestaoDeProjetos.Application.Interfaces;
using GestaoDeProjetos.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProjetos.API.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly IProjetoAppService _projetoAppService;

        public ProjetosController(IProjetoAppService projetoAppService)
        {
            _projetoAppService = projetoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarProjeto(CriarProjetoCommand command)
        {
            await _projetoAppService.CriarProjeto(command);

            return StatusCode(201, new
            {
                message = "Projeto cadastrado com sucesso.",
                command
            });
        }
        [HttpPost]
        public IActionResult ListarProjetos()
        {
            var projetos = _projetoAppService.ListarProjetos();
            return StatusCode(201, projetos);
            

        }
    }
}
