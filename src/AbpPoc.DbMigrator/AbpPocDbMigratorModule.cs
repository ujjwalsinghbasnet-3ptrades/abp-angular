using AbpPoc.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpPoc.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpPocEntityFrameworkCoreModule),
    typeof(AbpPocApplicationContractsModule)
)]
public class AbpPocDbMigratorModule : AbpModule
{
}
