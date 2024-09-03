using System;
using WavePlatform.Data;
using Serilog;
using Serilog.Events;
using Volo.Abp.Data;

namespace WavePlatform;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog((context, services, loggerConfiguration) =>
                {
                    loggerConfiguration
#if DEBUG
                        .MinimumLevel.Debug()
#else
                        .MinimumLevel.Information()
#endif
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                        .Enrich.FromLogContext()
                        .WriteTo.Async(c => c.File("Logs/logs.txt"))
                        .WriteTo.Async(c => c.Console());

                    if (IsMigrateDatabase(args))
                    {
                        loggerConfiguration.MinimumLevel.Override("Volo.Abp", LogEventLevel.Warning);
                        loggerConfiguration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
                    }
                    else
                    {
                        loggerConfiguration.WriteTo.Async(c => c.AbpStudio(services));
                    }
                });

            if (IsMigrateDatabase(args))
            {
                builder.Services.AddDataMigrationEnvironment();
            }

            // Configure CORS to allow specific origin with credentials
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", policyBuilder =>
                {
                    policyBuilder.WithOrigins("http://localhost:3000") // Replace with your frontend's URL
                           .AllowAnyMethod()    // Allow any HTTP method (GET, POST, etc.)
                           .AllowAnyHeader()    // Allow any HTTP headers
                           .AllowCredentials(); // Allow credentials (cookies, etc.)
                });
            });

            await builder.AddApplicationAsync<WavePlatformModule>();
            var app = builder.Build();

            // Apply CORS policy before initializing the application
            app.UseCors("AllowSpecificOrigin");

            await app.InitializeApplicationAsync();

            if (IsMigrateDatabase(args))
            {
                await app.Services.GetRequiredService<WavePlatformDbMigrationService>().MigrateAsync();
                return 0;
            }

            Log.Information("Starting WavePlatform.");
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "WavePlatform terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static bool IsMigrateDatabase(string[] args)
    {
        return args.Any(x => x.Contains("--migrate-database", StringComparison.OrdinalIgnoreCase));
    }
}
