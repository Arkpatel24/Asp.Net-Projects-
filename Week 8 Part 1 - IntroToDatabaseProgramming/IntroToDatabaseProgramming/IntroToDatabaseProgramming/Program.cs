using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace IntroToDatabaseProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = GetConnectionString("NorthwindLocal");
            Console.WriteLine(cs);
        }

        static string GetConnectionString(string connectionStringName)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("config.json");
            IConfiguration config = builder.Build();

            return config["ConnectionStrings:" + connectionStringName];
        }
    }
}
