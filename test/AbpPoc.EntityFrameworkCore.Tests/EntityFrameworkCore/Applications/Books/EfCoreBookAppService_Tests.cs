using AbpPoc.Books;
using Xunit;

namespace AbpPoc.EntityFrameworkCore.Applications.Books;

[Collection(AbpPocTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<AbpPocEntityFrameworkCoreTestModule>
{

}