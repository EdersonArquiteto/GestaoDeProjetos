using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Infra.Mongo.Settings
{
    public class MongoDBSettings
    {
        /// <summary>
        /// Servidor do MongoDB
        /// </summary>
        public string? Host { get; set; }

        /// <summary>
        /// Nome do banco de dados
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Security Socket Layer
        /// </summary>
        public bool IsSSL { get; set; }
    }
}
