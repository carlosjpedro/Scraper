using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ScraperApp.Models;
using ScraperApp.Settings;

namespace ScraperApp.Extensions;

public static class Extensions
{
    private const string AppSettingsFileName = "appsettings.json";

    public static IHostBuilder AddScraperClient(this IHostBuilder builder)
    {
        return builder.ConfigureServices((context, services) =>
        {
            services.Configure<ScraperClientSettings>(context.Configuration.GetSection("ScraperClientSettings"));
            services.AddHttpClient<IScraperClient, TvMazeScraperClient>((sp, client) =>
            {
                var settings = sp.GetRequiredService<IOptions<ScraperClientSettings>>();
                client.BaseAddress = new Uri(settings.Value.TvMazeUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        });
    }

    public static IHostBuilder AddConfiguration(this IHostBuilder builder)
    {
        return builder.ConfigureAppConfiguration((context, config) =>
        {
            config.AddJsonFile(AppSettingsFileName, optional: false);
            if (context.HostingEnvironment.IsDevelopment())
            {
                config.AddUserSecrets<Program>();

            }
        });
    }

    public static IHostBuilder AddLogging(this IHostBuilder builder)
    {
        return builder.ConfigureLogging((context, logging) =>
        {
            logging.AddConsole();
            logging.AddConfiguration(context.Configuration.GetSection("Logging"));
        });
    }

    public static IHostBuilder AddMapping(this IHostBuilder builder)
    {
     return   builder.ConfigureServices((context, services) =>
        {
            services.AddAutoMapper(typeof(TvShowMappingProfile));
        });
    }
}