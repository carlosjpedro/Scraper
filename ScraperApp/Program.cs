using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScraperApp.Extensions;

namespace ScraperApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .AddConfiguration()
                .AddScraperClient()
                .AddMapping()
                .AddLogging()
                .Build();

            var client = host.Services.GetRequiredService<IScraperClient>();
            var result = await client.GetShow(1);

            await client.GetShow(-1);

        }
    }
}
