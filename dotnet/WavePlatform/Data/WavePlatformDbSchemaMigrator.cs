using Volo.Abp.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace WavePlatform.Data;

public class WavePlatformDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public WavePlatformDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        
        /* We intentionally resolving the WavePlatformDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<WavePlatformDbContext>()
            .Database
            .MigrateAsync();

    }
}
