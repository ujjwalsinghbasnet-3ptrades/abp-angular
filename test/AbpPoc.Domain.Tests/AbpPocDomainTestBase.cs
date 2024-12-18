using Volo.Abp.Modularity;

namespace AbpPoc;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpPocDomainTestBase<TStartupModule> : AbpPocTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
