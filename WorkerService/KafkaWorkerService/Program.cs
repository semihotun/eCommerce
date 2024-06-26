using KafkaWorkerService.Extensions;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
namespace KafkaWorkerService
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.AddCqrsWithKafkaConsumerAsync();
            await host.RunAsync();
        }
        static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args);
    }
}
