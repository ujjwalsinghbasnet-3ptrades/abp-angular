using Volo.Abp.Modularity;

namespace AbpPoc;

[DependsOn(
    typeof(AbpPocDomainModule),
    typeof(AbpPocTestBaseModule)
)]
public class AbpPocDomainTestModule : AbpModule
{

}
