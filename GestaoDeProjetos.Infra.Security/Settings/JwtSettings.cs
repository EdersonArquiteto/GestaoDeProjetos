using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Infra.Security.Settings
{
    public class JwtSettings
    {
        /// <summary>
        /// Chave secreta antifalsificação do TOKEN
        /// </summary>
        public string? SecretKey { get; set; }

        /// <summary>
        /// Tempo de expiração do TOKEN em horas
        /// </summary>
        public int ExpirationInHours { get; set; }
    }
}
