using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using Pizzas.API.Models;
using Pizzas.API.Utils;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Helpers;
using Pizzas.API.Services;

namespace Pizzas.API.Helpers {
    public class ConfigurationHelper {
        public static IConfiguration GetConfiguration() {
            IConfiguration config;
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            config = builder.Build();
            return config;
        }
    }
}