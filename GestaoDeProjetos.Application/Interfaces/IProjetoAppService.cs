using GestaoDeProjetos.Application.Commands;
using GestaoDeProjetos.Domain.Models;
using GestaoDeProjetos.Infra.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Application.Interfaces
{
    public interface IProjetoAppService
    {
        Task CriarProjeto(CriarProjetoCommand command);
        List<ListarProjetoQuery> ListarProjetos();
    }
}
