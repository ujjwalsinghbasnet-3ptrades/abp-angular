using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpPoc.Data;
using Volo.Abp.DependencyInjection;

namespace AbpPoc.EntityFrameworkCore;

public class EntityFrameworkCoreAbpPocDbSchemaMigrator
    : IAbpPocDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAbpPocDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AbpPocDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpPocDbContext>()
            .Database
            .MigrateAsync();
    }
}
