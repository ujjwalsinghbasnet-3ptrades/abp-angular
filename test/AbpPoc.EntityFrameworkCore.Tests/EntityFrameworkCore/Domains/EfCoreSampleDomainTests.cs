using AbpPoc.Samples;
using Xunit;

namespace AbpPoc.EntityFrameworkCore.Domains;

[Collection(AbpPocTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AbpPocEntityFrameworkCoreTestModule>
{

}
