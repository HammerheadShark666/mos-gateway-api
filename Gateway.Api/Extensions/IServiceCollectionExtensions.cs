using Ocelot.DependencyInjection;

namespace Gateway.Api.Extensions;

public static class IServiceCollectionExtensions
{
    public static void ConfigureJwt(this IServiceCollection services)
    {
        services.AddJwtAuthentication();
    }

    public static void ConfigureOcelot(this IServiceCollection services, WebApplicationBuilder builder)
    { 
        IConfiguration configuration = new ConfigurationBuilder()
                           .SetBasePath(builder.Environment.ContentRootPath)  
                           .AddJsonFile($"ocelot.json", false, true) 
                           .AddOcelot($"Ocelot/{builder.Environment.EnvironmentName}/", builder.Environment)
                           .AddEnvironmentVariables()
                           .Build();

        builder.Services.AddOcelot(configuration);  
    }

    public static void ConfigureApplicationInsights(this IServiceCollection services)
    { 
        services.AddApplicationInsightsTelemetry();
    }
}