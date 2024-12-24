using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using AbpPoc.Documents;
using AbpPoc.EntityFrameworkCore;
using Xunit;

namespace AbpPoc.EntityFrameworkCore.Domains.Documents
{
    public class DocumentRepositoryTests : AbpPocEntityFrameworkCoreTestBase
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentRepositoryTests()
        {
            _documentRepository = GetRequiredService<IDocumentRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _documentRepository.GetListAsync(
                    name: "173b1b991c994c969dca57cf4d64133ddd586784ca6a44d287b058f3899307976154a695a77740d5b067545af08c33",
                    type: "a5d65e2793ba4afaa65d975ab911c"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("1e1323f6-98fe-4418-918b-f578cdaef905"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _documentRepository.GetCountAsync(
                    name: "fd26b578a7904032bde32dcbfaafd4c52d7565f211",
                    type: "5534f0cecfc843db9ca9e2"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}