﻿using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Infra.IntegrationTests.Helpers
{
    public class TestHelper
    {
        /// <summary>
        /// Método utilizado para criar uma instância da classe HttpClient
        /// Utilizada para fazer as chamadas para os serviços da API
        /// </summary>
        public HttpClient CreateClient()
        {
            return new WebApplicationFactory<Program>().CreateClient();
        }

        /// <summary>
        /// Método para serializar um objeto para JSON
        /// </summary>
        public StringContent CreateContent<TCommand>(TCommand command)
        {
            return new StringContent(JsonConvert.SerializeObject(command),
                Encoding.UTF8, "application/json");
        }
    }
}
