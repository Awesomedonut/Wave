using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WavePlatform.Data;

public class WavePlatformDbContextFactory : IDesignTimeDbContextFactory<WavePlatformDbContext>
{
    public WavePlatformDbContext CreateDbContext(string[] args)
    {
        WavePlatformEfCoreEntityExtensionMappings.Configure();
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<WavePlatformDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new WavePlatformDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}