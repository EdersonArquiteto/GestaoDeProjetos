using GestaoDeProjetos.Infra.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Infra.Mongo.Interfaces
{
    public interface ILogUsuariosPersistence
    {
        void Create(LogUsuarioModel model);
        void Update(LogUsuarioModel model);
        void Delete(LogUsuarioModel model);

        List<LogUsuarioModel> GetAll(DateTime dataMin, DateTime dataMax);
        List<LogUsuarioModel> GetAll(Guid usuarioId);
        List<LogUsuarioModel> GetAll(string email);
    }
}
