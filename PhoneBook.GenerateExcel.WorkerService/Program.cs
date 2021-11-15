using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBook.GenerateExcel.WorkerService.Models;
using PhoneBook.GenerateExcel.WorkerService.Services.RabbitMQ;
using RabbitMQ.Client;

namespace PhoneBook.GenerateExcel.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    services.AddDbContext<phonebookdbContext>(options=> 
                    {
                        options.UseNpgsql(configuration.GetConnectionString("phonebookdb"));
                    });

                    services.AddSingleton<RabbitMQClientService>();
                    services.AddSingleton(sp => new ConnectionFactory() 
                    {
                        HostName = configuration.GetConnectionString("rabbitMQ")
                        ,DispatchConsumersAsync=true
                    }
                    );
                    services.AddHostedService<Worker>();
                });


    }
}
