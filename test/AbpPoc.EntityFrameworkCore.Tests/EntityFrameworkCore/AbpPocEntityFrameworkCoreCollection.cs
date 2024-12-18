using Xunit;

namespace AbpPoc.EntityFrameworkCore;

[CollectionDefinition(AbpPocTestConsts.CollectionDefinitionName)]
public class AbpPocEntityFrameworkCoreCollection : ICollectionFixture<AbpPocEntityFrameworkCoreFixture>
{

}
