using App.Web.Modules;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace WebApplication6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Serilog iþlemleri
            IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        // autofac module ekleme
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new RepositoryServiceModule());
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseSerilog();
                });
    }
}
