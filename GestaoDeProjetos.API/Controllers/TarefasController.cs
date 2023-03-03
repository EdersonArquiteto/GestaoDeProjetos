using GestaoDeProjetos.Application.Commands;
using GestaoDeProjetos.Application.Interfaces;
using GestaoDeProjetos.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProjetos.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaAppService _tarefaAppService;

        public TarefasController(ITarefaAppService tarefaAppService)
        {
            _tarefaAppService = tarefaAppService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarTarefa(CriarTarefaCommand command)
        {
            await _tarefaAppService.CriarTarefa(command);

            return StatusCode(201, new
            {
                message = "Tarefa cadastrada com sucesso.",
                command
            });
        }

    }
}
