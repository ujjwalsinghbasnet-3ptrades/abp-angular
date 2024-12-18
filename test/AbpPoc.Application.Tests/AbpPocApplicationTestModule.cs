using Volo.Abp.Modularity;

namespace AbpPoc;

[DependsOn(
    typeof(AbpPocApplicationModule),
    typeof(AbpPocDomainTestModule)
)]
public class AbpPocApplicationTestModule : AbpModule
{

}
