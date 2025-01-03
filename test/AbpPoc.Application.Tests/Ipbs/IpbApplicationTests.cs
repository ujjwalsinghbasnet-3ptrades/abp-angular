using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace AbpPoc.Ipbs
{
    public abstract class IpbsAppServiceTests<TStartupModule> : AbpPocApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IIpbsAppService _ipbsAppService;
        private readonly IRepository<Ipb, Guid> _ipbRepository;

        public IpbsAppServiceTests()
        {
            _ipbsAppService = GetRequiredService<IIpbsAppService>();
            _ipbRepository = GetRequiredService<IRepository<Ipb, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _ipbsAppService.GetListAsync(new GetIpbsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Ipb.Id == Guid.Parse("c3c6963b-34bd-4f9d-b8d7-cd177d090ce0")).ShouldBe(true);
            result.Items.Any(x => x.Ipb.Id == Guid.Parse("3c48de7f-35cc-4f7b-851f-b678082fe5df")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _ipbsAppService.GetAsync(Guid.Parse("c3c6963b-34bd-4f9d-b8d7-cd177d090ce0"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("c3c6963b-34bd-4f9d-b8d7-cd177d090ce0"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new IpbCreateDto
            {
                figureName = "1ba953f32aa9425395a98c6137584d5d40a2cf66143c48349238d1013c65bf9379c8ddb923ff445b9a915ce08f7524d0245e87e42bb24ac19ac439a18f34e404bfb2bf9fc08340338ba8e0ceb762188ed5dc241ead1d4e3e98f021b25d00cbbdc630314083034ea48cda1fd36d90983338860fa6d799416786f209b85ed5df6c",
                figureNumber = "f2d43db607ae4bd1aaa246820f8dd059",
                toNumber = "93165e216b6b4f2e8b447054126e20205769af40d3c947fa8aa36ff786521ebf1852214f1cb44969a5e3133c170d71729af5b735683f464fb9be9ef822ab6ed4ceb35563723e4283ac03b3c802c00c45d104b30a4dfe4a47b4c6367375749f633b13d193bf734c8ea02e527e095805d805e85d480b5b42b3b78e729f0125eb47378c04d3a9d84e169de564768b0c7db3cadb845f26c74ca598e6a059400aab1d5bc2b8f148bd4278bc608d8c74c8172feea95f04e0014154bd661bbab019c7cf9104f3d3b53e44ae9935f9b7d024909a5b1a0095889a4293a27a0dec05703af5d5fe2bfe4ff54dd486dcf2340543c328f93da3327529472286ed7d4d65abb4ce",
                indentureLevel = "0bb04706"
            };

            // Act
            var serviceResult = await _ipbsAppService.CreateAsync(input);

            // Assert
            var result = await _ipbRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.figureName.ShouldBe("1ba953f32aa9425395a98c6137584d5d40a2cf66143c48349238d1013c65bf9379c8ddb923ff445b9a915ce08f7524d0245e87e42bb24ac19ac439a18f34e404bfb2bf9fc08340338ba8e0ceb762188ed5dc241ead1d4e3e98f021b25d00cbbdc630314083034ea48cda1fd36d90983338860fa6d799416786f209b85ed5df6c");
            result.figureNumber.ShouldBe("f2d43db607ae4bd1aaa246820f8dd059");
            result.toNumber.ShouldBe("93165e216b6b4f2e8b447054126e20205769af40d3c947fa8aa36ff786521ebf1852214f1cb44969a5e3133c170d71729af5b735683f464fb9be9ef822ab6ed4ceb35563723e4283ac03b3c802c00c45d104b30a4dfe4a47b4c6367375749f633b13d193bf734c8ea02e527e095805d805e85d480b5b42b3b78e729f0125eb47378c04d3a9d84e169de564768b0c7db3cadb845f26c74ca598e6a059400aab1d5bc2b8f148bd4278bc608d8c74c8172feea95f04e0014154bd661bbab019c7cf9104f3d3b53e44ae9935f9b7d024909a5b1a0095889a4293a27a0dec05703af5d5fe2bfe4ff54dd486dcf2340543c328f93da3327529472286ed7d4d65abb4ce");
            result.indentureLevel.ShouldBe("0bb04706");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new IpbUpdateDto()
            {
                figureName = "5767eec411214e1d8673605c51c172a78ae8e3c5a3164155a74251dcc27c16308b0062dd7c4b452682c2401f7424836050bdaf3de43c481c85d31b219f7af96a1852b4a0ffec4efd8a83ede1d921220044bffef4a125474a9c8cdf749481676799029b5f496143768faa553524330b4af580412218c8480ea45a204954876285",
                figureNumber = "2157eb7341134f688fe8ade83302b889",
                toNumber = "de31e7f93a66420da119e2eb4e2fb9d854f82faf186a4afca9d6f88f7a8f7aee99f5cadbe8b34c0189df81d9062ed44a7fb69c33350d4e0e87309c241fa6f050495bae1285294eca8831176d69c1554541efa1e3d0b14b8c88555ca3c5bb9e22ce27915a85d7408a9662ba4c8ea6e431dc473a1c04d4459d90ca623e08f90412da294ff576f84dadb6c2bb6735e0756c311396d78e024ff691407a70142829364f784a875b624da1999c928f50d55d47e1de2d7b7c6544239c672f4f9ac1edeb588e847ce2d34186b3a29be89d5b783cc0358d0b7cc94e73830879575c5dd504d0db32fd8fcd4244ab131a72ea49d166b9d84b38c3c1478c90e6d481d92ebe32",
                indentureLevel = "81133845"
            };

            // Act
            var serviceResult = await _ipbsAppService.UpdateAsync(Guid.Parse("c3c6963b-34bd-4f9d-b8d7-cd177d090ce0"), input);

            // Assert
            var result = await _ipbRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.figureName.ShouldBe("5767eec411214e1d8673605c51c172a78ae8e3c5a3164155a74251dcc27c16308b0062dd7c4b452682c2401f7424836050bdaf3de43c481c85d31b219f7af96a1852b4a0ffec4efd8a83ede1d921220044bffef4a125474a9c8cdf749481676799029b5f496143768faa553524330b4af580412218c8480ea45a204954876285");
            result.figureNumber.ShouldBe("2157eb7341134f688fe8ade83302b889");
            result.toNumber.ShouldBe("de31e7f93a66420da119e2eb4e2fb9d854f82faf186a4afca9d6f88f7a8f7aee99f5cadbe8b34c0189df81d9062ed44a7fb69c33350d4e0e87309c241fa6f050495bae1285294eca8831176d69c1554541efa1e3d0b14b8c88555ca3c5bb9e22ce27915a85d7408a9662ba4c8ea6e431dc473a1c04d4459d90ca623e08f90412da294ff576f84dadb6c2bb6735e0756c311396d78e024ff691407a70142829364f784a875b624da1999c928f50d55d47e1de2d7b7c6544239c672f4f9ac1edeb588e847ce2d34186b3a29be89d5b783cc0358d0b7cc94e73830879575c5dd504d0db32fd8fcd4244ab131a72ea49d166b9d84b38c3c1478c90e6d481d92ebe32");
            result.indentureLevel.ShouldBe("81133845");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _ipbsAppService.DeleteAsync(Guid.Parse("c3c6963b-34bd-4f9d-b8d7-cd177d090ce0"));

            // Assert
            var result = await _ipbRepository.FindAsync(c => c.Id == Guid.Parse("c3c6963b-34bd-4f9d-b8d7-cd177d090ce0"));

            result.ShouldBeNull();
        }
    }
}