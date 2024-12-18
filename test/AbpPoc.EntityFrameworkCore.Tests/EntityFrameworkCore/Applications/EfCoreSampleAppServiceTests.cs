using AbpPoc.Samples;
using Xunit;

namespace AbpPoc.EntityFrameworkCore.Applications;

[Collection(AbpPocTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AbpPocEntityFrameworkCoreTestModule>
{

}
