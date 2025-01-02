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
            result.Items.Any(x => x.Ipb.Id == Guid.Parse("972fa525-d23b-4818-9924-621d597c8445")).ShouldBe(true);
            result.Items.Any(x => x.Ipb.Id == Guid.Parse("d4be035a-63dd-4e33-ad73-5215311c83d5")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _ipbsAppService.GetAsync(Guid.Parse("972fa525-d23b-4818-9924-621d597c8445"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("972fa525-d23b-4818-9924-621d597c8445"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new IpbCreateDto
            {
                ipbIndex = "2850b977",
                figureName = "976058878f1a4af68376886fc0a5458b791b61cec6b843c18fa80ca7ca7b426372a9883e1eb64e6ab620cfe5aaf627824e2dceaea5f647f6a1a39f79ac2f2df4dc282e8f401c4d0b9ef885bf716108657cd49c2a2e0046228a46bbf338510c27e4dbf39370f9491b93396dec15db9ffe0f2c1bd921bd4d5e9e93befe8f4833ce",
                figureNumber = "9327d65b0b5a4931a83c425be3b15dbcf8fa6fb3cd414b69bce99260a7e8ade9ef1834e6efc8477ea096e49968c000af33988f4051174b84b23006e475c5c135c43ec89f686e43eca7b851010e8ad96f26a8e7af123e4784b0949996b5e6edf1eebeeccf7be34feeba7cfa5977bbc1a9f983c6825cba42f488f372448f21815d",
                toNumber = "f5bfe7c94c6640dc96bc3382769a1cfe",
                indentureLevel = "a2e21afb",
                sourceId = "a5a7f5b6c82440c9bd103e0215c48666da2c4e62d8fd4e8198467de4d53fd4fa825a388ef7ce4145",
                relatedId = "99071a1613594caaa87c54b721570996bf4a308bf21a4bf596fbb1fa0a10"
            };

            // Act
            var serviceResult = await _ipbsAppService.CreateAsync(input);

            // Assert
            var result = await _ipbRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ipbIndex.ShouldBe("2850b977");
            result.figureName.ShouldBe("976058878f1a4af68376886fc0a5458b791b61cec6b843c18fa80ca7ca7b426372a9883e1eb64e6ab620cfe5aaf627824e2dceaea5f647f6a1a39f79ac2f2df4dc282e8f401c4d0b9ef885bf716108657cd49c2a2e0046228a46bbf338510c27e4dbf39370f9491b93396dec15db9ffe0f2c1bd921bd4d5e9e93befe8f4833ce");
            result.figureNumber.ShouldBe("9327d65b0b5a4931a83c425be3b15dbcf8fa6fb3cd414b69bce99260a7e8ade9ef1834e6efc8477ea096e49968c000af33988f4051174b84b23006e475c5c135c43ec89f686e43eca7b851010e8ad96f26a8e7af123e4784b0949996b5e6edf1eebeeccf7be34feeba7cfa5977bbc1a9f983c6825cba42f488f372448f21815d");
            result.toNumber.ShouldBe("f5bfe7c94c6640dc96bc3382769a1cfe");
            result.indentureLevel.ShouldBe("a2e21afb");
            result.sourceId.ShouldBe("a5a7f5b6c82440c9bd103e0215c48666da2c4e62d8fd4e8198467de4d53fd4fa825a388ef7ce4145");
            result.relatedId.ShouldBe("99071a1613594caaa87c54b721570996bf4a308bf21a4bf596fbb1fa0a10");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new IpbUpdateDto()
            {
                ipbIndex = "cd206af1",
                figureName = "b4dbd2039ea84ab7b3d5366bd40fa3cfdea482ee987f4dec9cbae4a8ca61dd58eb4f4467be7e482a9e561e5c228774f2db5fff00fba0420a88945eee8c0d4f611ac532829d66420485c02ffe6f3513b40f7d6fcdba8c4dda8595745732591d8c23918fad090148c783f986708347ed57159d3ac260874b5e88d2f863c1d406f3",
                figureNumber = "2e55277db46347aca9a45a16e8554ee03a335108841c42dfa35617026a6ad0fad64014d8b7584c17b9550db40853ccbaf53e21e3543c4000aed239aebacc1c2480be756cbf5f4088ba56638163a681e5a81c9318e8c845228ad78cae62279bbc3b246fb58ba8474cb2de3ad3e757093a51c43116943046adac3ddc24465971a5",
                toNumber = "9659e5c4c92042f2b80fb4e2d67ba923",
                indentureLevel = "7757918f",
                sourceId = "e6008dcde163419d82592c95c1c479dd46d1245c1b0248cb9ba2c74ec342c87e6d317b2f1c2140",
                relatedId = "e7aad68f931f45eca916101999c173d6248b443da1724"
            };

            // Act
            var serviceResult = await _ipbsAppService.UpdateAsync(Guid.Parse("972fa525-d23b-4818-9924-621d597c8445"), input);

            // Assert
            var result = await _ipbRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ipbIndex.ShouldBe("cd206af1");
            result.figureName.ShouldBe("b4dbd2039ea84ab7b3d5366bd40fa3cfdea482ee987f4dec9cbae4a8ca61dd58eb4f4467be7e482a9e561e5c228774f2db5fff00fba0420a88945eee8c0d4f611ac532829d66420485c02ffe6f3513b40f7d6fcdba8c4dda8595745732591d8c23918fad090148c783f986708347ed57159d3ac260874b5e88d2f863c1d406f3");
            result.figureNumber.ShouldBe("2e55277db46347aca9a45a16e8554ee03a335108841c42dfa35617026a6ad0fad64014d8b7584c17b9550db40853ccbaf53e21e3543c4000aed239aebacc1c2480be756cbf5f4088ba56638163a681e5a81c9318e8c845228ad78cae62279bbc3b246fb58ba8474cb2de3ad3e757093a51c43116943046adac3ddc24465971a5");
            result.toNumber.ShouldBe("9659e5c4c92042f2b80fb4e2d67ba923");
            result.indentureLevel.ShouldBe("7757918f");
            result.sourceId.ShouldBe("e6008dcde163419d82592c95c1c479dd46d1245c1b0248cb9ba2c74ec342c87e6d317b2f1c2140");
            result.relatedId.ShouldBe("e7aad68f931f45eca916101999c173d6248b443da1724");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _ipbsAppService.DeleteAsync(Guid.Parse("972fa525-d23b-4818-9924-621d597c8445"));

            // Assert
            var result = await _ipbRepository.FindAsync(c => c.Id == Guid.Parse("972fa525-d23b-4818-9924-621d597c8445"));

            result.ShouldBeNull();
        }
    }
}