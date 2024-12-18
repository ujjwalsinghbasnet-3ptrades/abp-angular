using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace AbpPoc.Parts
{
    public abstract class PartsAppServiceTests<TStartupModule> : AbpPocApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IPartsAppService _partsAppService;
        private readonly IRepository<Part, Guid> _partRepository;

        public PartsAppServiceTests()
        {
            _partsAppService = GetRequiredService<IPartsAppService>();
            _partRepository = GetRequiredService<IRepository<Part, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _partsAppService.GetListAsync(new GetPartsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("218e0563-5ee5-407f-a06c-591425acceb9")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("65cd60da-c218-4d7a-8f3f-4ae736ac0726")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _partsAppService.GetAsync(Guid.Parse("218e0563-5ee5-407f-a06c-591425acceb9"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("218e0563-5ee5-407f-a06c-591425acceb9"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PartCreateDto
            {
                name = "d4c",
                description = "8101e3bedec9401488a1c357f7",
                partNumber = "6ad885",
                cageCode = "12d280a21f074ffc926b6ae77d990a0d2",
                toNumber = "fa7cf3d5fa764be284159fc6d8c17d39045ac04875c2471184c0b4d36552e7708a5b278077384efabaa",
                distributionStatement = "147f347a894640eda5388ba3daf67eb63",
                smr = "b0957d9f8e9348e",
                niin = "d2fdcc24536c42919bc4a84d2622915796f1e28a0a9549f7b8acdd2291e7f8f8d1c264291836459389a67",
                fsc = "cc7ed0557f404014832db470084ce018a",
                wuc = "ebe8822a22944e668561f75580",
                uoc = "019453b2a2ba44afa2ea4ab3e0af2d0ea7a03ad0cdb841f49533a9954f62d0a",
                uniqueId = "a4d0d0b5",
                nsn = "003b23bae7",
                imageUrl = "40685806a76842ff96a9dc07ae018241af996d752b0e4e9299cf241813fd14b08c9fb67d"
            };

            // Act
            var serviceResult = await _partsAppService.CreateAsync(input);

            // Assert
            var result = await _partRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.name.ShouldBe("d4c");
            result.description.ShouldBe("8101e3bedec9401488a1c357f7");
            result.partNumber.ShouldBe("6ad885");
            result.cageCode.ShouldBe("12d280a21f074ffc926b6ae77d990a0d2");
            result.toNumber.ShouldBe("fa7cf3d5fa764be284159fc6d8c17d39045ac04875c2471184c0b4d36552e7708a5b278077384efabaa");
            result.distributionStatement.ShouldBe("147f347a894640eda5388ba3daf67eb63");
            result.smr.ShouldBe("b0957d9f8e9348e");
            result.niin.ShouldBe("d2fdcc24536c42919bc4a84d2622915796f1e28a0a9549f7b8acdd2291e7f8f8d1c264291836459389a67");
            result.fsc.ShouldBe("cc7ed0557f404014832db470084ce018a");
            result.wuc.ShouldBe("ebe8822a22944e668561f75580");
            result.uoc.ShouldBe("019453b2a2ba44afa2ea4ab3e0af2d0ea7a03ad0cdb841f49533a9954f62d0a");
            result.uniqueId.ShouldBe("a4d0d0b5");
            result.nsn.ShouldBe("003b23bae7");
            result.imageUrl.ShouldBe("40685806a76842ff96a9dc07ae018241af996d752b0e4e9299cf241813fd14b08c9fb67d");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PartUpdateDto()
            {
                name = "193",
                description = "a959f74a890d446fb39f6637772227fc04fcbdf03a5a4c39970fb111284325d",
                partNumber = "f922be6447074ca2a82b7d6c9d6dd643e754063717224d13beb14dc0a46827f",
                cageCode = "03265c2816c5456d9d65bac30c3a794a480fc7594387499aae",
                toNumber = "8240adc41",
                distributionStatement = "a6aea649348d43559e75a056c97fed6925cbf2a0af6e4",
                smr = "bf8de2426fcc40718037ca255bc999c27f27ee36e56b41908eee59ede953e346b0",
                niin = "b2b341721e844c55af139a4960c6808bdf133f825742440fadaebf2ec0770dd148705c9d120440d2aaf05ab5aa4a3a",
                fsc = "e68f29dc7bea4507",
                wuc = "9c51886bbb3a42639ab44549062070110cdb9463f3724d709e2bae",
                uoc = "c4fa80",
                uniqueId = "b75655a4ffa147c3a28642c9322547491549a85689454",
                nsn = "cbd6a4c8f2714a2088b49da11b35399fc54c6afbd7f94df182cc582c57ab97267eba8b892e874fb4af8565879",
                imageUrl = "32d6c11fee1b429390fbf2fe2ebdf1fabcc1d66abe934577aa0458cc86dcf11a8333348dbd5f4e01a"
            };

            // Act
            var serviceResult = await _partsAppService.UpdateAsync(Guid.Parse("218e0563-5ee5-407f-a06c-591425acceb9"), input);

            // Assert
            var result = await _partRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.name.ShouldBe("193");
            result.description.ShouldBe("a959f74a890d446fb39f6637772227fc04fcbdf03a5a4c39970fb111284325d");
            result.partNumber.ShouldBe("f922be6447074ca2a82b7d6c9d6dd643e754063717224d13beb14dc0a46827f");
            result.cageCode.ShouldBe("03265c2816c5456d9d65bac30c3a794a480fc7594387499aae");
            result.toNumber.ShouldBe("8240adc41");
            result.distributionStatement.ShouldBe("a6aea649348d43559e75a056c97fed6925cbf2a0af6e4");
            result.smr.ShouldBe("bf8de2426fcc40718037ca255bc999c27f27ee36e56b41908eee59ede953e346b0");
            result.niin.ShouldBe("b2b341721e844c55af139a4960c6808bdf133f825742440fadaebf2ec0770dd148705c9d120440d2aaf05ab5aa4a3a");
            result.fsc.ShouldBe("e68f29dc7bea4507");
            result.wuc.ShouldBe("9c51886bbb3a42639ab44549062070110cdb9463f3724d709e2bae");
            result.uoc.ShouldBe("c4fa80");
            result.uniqueId.ShouldBe("b75655a4ffa147c3a28642c9322547491549a85689454");
            result.nsn.ShouldBe("cbd6a4c8f2714a2088b49da11b35399fc54c6afbd7f94df182cc582c57ab97267eba8b892e874fb4af8565879");
            result.imageUrl.ShouldBe("32d6c11fee1b429390fbf2fe2ebdf1fabcc1d66abe934577aa0458cc86dcf11a8333348dbd5f4e01a");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _partsAppService.DeleteAsync(Guid.Parse("218e0563-5ee5-407f-a06c-591425acceb9"));

            // Assert
            var result = await _partRepository.FindAsync(c => c.Id == Guid.Parse("218e0563-5ee5-407f-a06c-591425acceb9"));

            result.ShouldBeNull();
        }
    }
}