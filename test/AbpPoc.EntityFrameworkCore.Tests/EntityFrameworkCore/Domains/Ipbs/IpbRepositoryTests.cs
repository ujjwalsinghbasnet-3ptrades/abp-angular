using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using AbpPoc.Ipbs;
using AbpPoc.EntityFrameworkCore;
using Xunit;

namespace AbpPoc.EntityFrameworkCore.Domains.Ipbs
{
    public class IpbRepositoryTests : AbpPocEntityFrameworkCoreTestBase
    {
        private readonly IIpbRepository _ipbRepository;

        public IpbRepositoryTests()
        {
            _ipbRepository = GetRequiredService<IIpbRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _ipbRepository.GetListAsync(
                    figureName: "dd0b57fa949c4d4a905449fb032798707d747ecff08a4bf298bd4f2a99383c357424ffd6ca1649b3bb9c52406ecdcee5f1e34718146f4b9fa355b6f598872ed53339e16f06ff4b5483a3e1fc7291f9a03ddb9c8d5ee94026a2080a4be161f7c570cbb9b6026e4ca7b54f46f1f5b2e573848b2e105d4843b7929e058c6207d730",
                    figureNumber: "c24976d731c941a483b47c24be7a758b",
                    toNumber: "9470b4a7b6df457fa3271710b3476d0a63e104a33d094b679ff42e7eebd88dc50e26848d95f94f469db1f94b34af77fd8d9c105c1a834ac3a5cff8a18bb6b7c7d7d3e4bf5f09415ca785ab4a4b2b70dd2fec824749dd4f9e8e8bd37081b7e36809ee135d7e6349c0bd3b9c4171417648208b4a84b1b54ee6ad010ff9aee5e04efbda33ae9f2943a1a2b40bb84dc349c8a52aa3da8b4c4b3cafc8f8b98d90a63b5443c2bbcf874fdfbafaf3ab47984d1b3a0147e3d4074704915236931c054d37f244211f367f4aeeab529c0250be30c57540129603f843589e34ed28fd6ced647fc2e76762294b9e9af7408d709abc78596c8e1482f544618d89d774075c17c4",
                    indentureLevel: "13970bbd"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("c3c6963b-34bd-4f9d-b8d7-cd177d090ce0"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _ipbRepository.GetCountAsync(
                    figureName: "917c977c43fa42a18188761f2340a993dde4aab9d4674957915bad61ee34e3656ac532fd75a24c9b965154d6d4de6db244d3825c6f064867a7ec0c00da69609558b81c9d073040699327dc69d013370794278d8a661f47d6af1dd61aee06e44b78813bc3972647d0ae6ff6d00e581b5ad082a04df6ff4b5bb75bffc26d6f4831",
                    figureNumber: "7d9d63d4b2d14203a2ca468fdafb6eb3",
                    toNumber: "9a248f6052e64267b13648cb1f36c1b9881a8739b49d44faadf21e518bf560be1d88cf34cd5d4aa2a1b86f4fec2963b7fdcd47c5b9584831855cbb40a8d0d559a888b0dc355640a8a889b99b6ab5df52136a281c92f0400faccd256aca8508d389c14fec11a94cd7917f39931ee2b5f40226d72d6186488eb042fe1121a0ece186cad29c9b5b4a01a6345ec5bdc16a1e05e3bb151c884934ac64d43cf1600414d8a34603859c484a922c546dd5a52f12f3af25f1aade4a998c0dc283128baa8422360d113ca34fd793b575d5e779deb123ec85a47b9a4f2d9bac17010650615b0801f20c3ed542f88c0f76792692a2310a9d4a4613634bcfa81849cd62895544",
                    indentureLevel: "84bdd1b6"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}