using GestaoDeProjetos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Domain.Interfaces.Services
{
    public interface IProjetoDomainService : IDisposable
    {
        void CriarProjeto(Projeto projeto);
        List<Projeto> ListarProjeto();
        
    }
}
