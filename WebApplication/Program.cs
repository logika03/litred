using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplication.Jobs;
using WebApplication.Migrations;

namespace WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            // var port = Environment.GetEnvironmentVariable("PORT");
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    // .UseUrls("https://the-best-library.herokuapp.com/");
                });
        }
    }
}
//    "WebApplicationContextConnection": "Host=localhost;Port=5432;Database=library5;Username=postgres;Password=postgres"
//postgres://ytepndnmnukdek:af727955e86be325aabc5b7cb2f47869f51f6a75c5aedae487b7fca8ed38f300@ec2-54-228-174-49.eu-west-1.compute.amazonaws.com:5432/d77ffutvb17o5s