using Volo.Abp.Modularity;

namespace AbpPoc;

public abstract class AbpPocApplicationTestBase<TStartupModule> : AbpPocTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
