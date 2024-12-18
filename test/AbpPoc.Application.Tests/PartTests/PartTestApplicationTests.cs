using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace AbpPoc.PartTests
{
    public abstract class PartTestsAppServiceTests<TStartupModule> : AbpPocApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IPartTestsAppService _partTestsAppService;
        private readonly IRepository<PartTest, Guid> _partTestRepository;

        public PartTestsAppServiceTests()
        {
            _partTestsAppService = GetRequiredService<IPartTestsAppService>();
            _partTestRepository = GetRequiredService<IRepository<PartTest, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _partTestsAppService.GetListAsync(new GetPartTestsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("cd2d84d3-6d16-441c-9fdd-f41451f29fd2")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("3901aef8-f48d-4395-a578-2d9971174315")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _partTestsAppService.GetAsync(Guid.Parse("cd2d84d3-6d16-441c-9fdd-f41451f29fd2"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("cd2d84d3-6d16-441c-9fdd-f41451f29fd2"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PartTestCreateDto
            {
                partNumber = "e9e8719acc494386b2db071741a55281d8aa1eab86ef45b7b7fd6e318dfe6b535",
                name = "9cce8b828bb4453da11ec5b3067190b5289341164bf547e0ae0797babd",
                cageCode = "5bde209f857d4d5296a0eacf38ae6cc74eb",
                distributionStatement = "4454f39757a44e94a2b48d69fcbf28037d9bef3cbdc3481eb634118ea133020198b23fef052644ff8dc6e9191ce1eb8bfd",
                toNumber = "833a127277554052b3b4fd6d20af",
                smr = "145967b90531428c907fdb45d180b07ac95f5121d6154ed2835abb511609b5fd",
                niin = "9d5574a4ee984c2d88",
                fsc = "e767b6a84d3f477d946b1af4e1b3b23530759c5392fe4ecba2db493825da146b94b1ae0b713c449cb96c0209b",
                wuc = "8619d0eca63e46c7bc3cbcca177e7090f1c4251a3c0f4cee90c6ea80f305e8ba84baadcba3b7449590c7087635ad",
                uoc = "a310562272b14c49bef04842c1e960f0436acd1b2a1a48b995e2b8516400a6d3c93899e4630d",
                uniqueId = "2570ad824af241c697d250ecb6759557f6bc68c09246454d929b7e6ad7a6f7610c40c89847a0",
                nsn = "a1edcd0dee0f41a48e84a67639e48f3bf9a0f03f8b204f9d82f7b4",
                imageUrl = "6a17ec16d71a4c"
            };

            // Act
            var serviceResult = await _partTestsAppService.CreateAsync(input);

            // Assert
            var result = await _partTestRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.partNumber.ShouldBe("e9e8719acc494386b2db071741a55281d8aa1eab86ef45b7b7fd6e318dfe6b535");
            result.name.ShouldBe("9cce8b828bb4453da11ec5b3067190b5289341164bf547e0ae0797babd");
            result.cageCode.ShouldBe("5bde209f857d4d5296a0eacf38ae6cc74eb");
            result.distributionStatement.ShouldBe("4454f39757a44e94a2b48d69fcbf28037d9bef3cbdc3481eb634118ea133020198b23fef052644ff8dc6e9191ce1eb8bfd");
            result.toNumber.ShouldBe("833a127277554052b3b4fd6d20af");
            result.smr.ShouldBe("145967b90531428c907fdb45d180b07ac95f5121d6154ed2835abb511609b5fd");
            result.niin.ShouldBe("9d5574a4ee984c2d88");
            result.fsc.ShouldBe("e767b6a84d3f477d946b1af4e1b3b23530759c5392fe4ecba2db493825da146b94b1ae0b713c449cb96c0209b");
            result.wuc.ShouldBe("8619d0eca63e46c7bc3cbcca177e7090f1c4251a3c0f4cee90c6ea80f305e8ba84baadcba3b7449590c7087635ad");
            result.uoc.ShouldBe("a310562272b14c49bef04842c1e960f0436acd1b2a1a48b995e2b8516400a6d3c93899e4630d");
            result.uniqueId.ShouldBe("2570ad824af241c697d250ecb6759557f6bc68c09246454d929b7e6ad7a6f7610c40c89847a0");
            result.nsn.ShouldBe("a1edcd0dee0f41a48e84a67639e48f3bf9a0f03f8b204f9d82f7b4");
            result.imageUrl.ShouldBe("6a17ec16d71a4c");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PartTestUpdateDto()
            {
                partNumber = "5801be3f2a1f44519e66add3a7989be0ee0aa9aea1ef4b84a7ae1355",
                name = "eeb3f88f5d73438291b1b618336419e2da379978033f4700a34a9ee970b5e6465a028fbcfe",
                cageCode = "e0508ddef54a4405a3974043bfdbc739bbdd1550364545c4bab8d248772a486fff46703815a941b28f1e2f3aaa499801",
                distributionStatement = "b6d13beb91f04b6bb8fc8cf",
                toNumber = "eda600916d5541c5bed62f8677ae0b4e6b5d47",
                smr = "bba9606f4b4a4a7ead7e3737a",
                niin = "c92afc7406cb4d0aa1b5f95c3eb09051436ed803a77740d3bd035d5b3",
                fsc = "3a130da9494d4e8db777a6e6fd9ec3f2f068c92a5d02416788b37e67a102562f8e8f8bb3eccc403eb24",
                wuc = "a6f50e67c1124",
                uoc = "c80a5733b71a4c32ab832d3a412119270df111796",
                uniqueId = "1677895a503d4930b8cebbb02732ba5a6d0261212815466da10009402365e7af3f55de913",
                nsn = "3822a69e66f045f39e2f50fe9a50d38f8686af7310f24559947277065545d3d116b",
                imageUrl = "2ad1d6590b1848e49aa239f2f638ca4b264cddfc7b644324abf5d972558312a9ad722309f"
            };

            // Act
            var serviceResult = await _partTestsAppService.UpdateAsync(Guid.Parse("cd2d84d3-6d16-441c-9fdd-f41451f29fd2"), input);

            // Assert
            var result = await _partTestRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.partNumber.ShouldBe("5801be3f2a1f44519e66add3a7989be0ee0aa9aea1ef4b84a7ae1355");
            result.name.ShouldBe("eeb3f88f5d73438291b1b618336419e2da379978033f4700a34a9ee970b5e6465a028fbcfe");
            result.cageCode.ShouldBe("e0508ddef54a4405a3974043bfdbc739bbdd1550364545c4bab8d248772a486fff46703815a941b28f1e2f3aaa499801");
            result.distributionStatement.ShouldBe("b6d13beb91f04b6bb8fc8cf");
            result.toNumber.ShouldBe("eda600916d5541c5bed62f8677ae0b4e6b5d47");
            result.smr.ShouldBe("bba9606f4b4a4a7ead7e3737a");
            result.niin.ShouldBe("c92afc7406cb4d0aa1b5f95c3eb09051436ed803a77740d3bd035d5b3");
            result.fsc.ShouldBe("3a130da9494d4e8db777a6e6fd9ec3f2f068c92a5d02416788b37e67a102562f8e8f8bb3eccc403eb24");
            result.wuc.ShouldBe("a6f50e67c1124");
            result.uoc.ShouldBe("c80a5733b71a4c32ab832d3a412119270df111796");
            result.uniqueId.ShouldBe("1677895a503d4930b8cebbb02732ba5a6d0261212815466da10009402365e7af3f55de913");
            result.nsn.ShouldBe("3822a69e66f045f39e2f50fe9a50d38f8686af7310f24559947277065545d3d116b");
            result.imageUrl.ShouldBe("2ad1d6590b1848e49aa239f2f638ca4b264cddfc7b644324abf5d972558312a9ad722309f");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _partTestsAppService.DeleteAsync(Guid.Parse("cd2d84d3-6d16-441c-9fdd-f41451f29fd2"));

            // Assert
            var result = await _partTestRepository.FindAsync(c => c.Id == Guid.Parse("cd2d84d3-6d16-441c-9fdd-f41451f29fd2"));

            result.ShouldBeNull();
        }
    }
}