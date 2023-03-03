using GestaoDeProjetos.Infra.Mongo.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Application.Notifications
{
    public class LogUsuariosNotificationHandler : INotificationHandler<LogUsuariosNotification>
    {
        //atributos
        private readonly ILogUsuariosPersistence _logUsuariosPersistence;

        public LogUsuariosNotificationHandler(ILogUsuariosPersistence logUsuariosPersistence)
        {
            _logUsuariosPersistence = logUsuariosPersistence;
        }

        /// <summary>
        /// Método para acessar o banco de cache e gravar os dados do log
        /// </summary>
        public Task Handle(LogUsuariosNotification notification, CancellationToken cancellationToken)
        {
            //gravar os dados no banco de cache
            return Task.Run(() =>
            {
                _logUsuariosPersistence.Create(notification.LogUsuario);
            });
        }
    }
}
