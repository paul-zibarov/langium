using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Langium.DataLayer
{
    public class DbConnectionProvider
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}
