using GestaoDeProjetos.Infra.Mongo.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Application.Notifications
{
    public class LogUsuariosNotification : INotification
    {
        /// <summary>
        /// Modelo de dados que será gravado na base de cache/consulta
        /// </summary>
        public LogUsuarioModel? LogUsuario { get; set; }
    }
}
