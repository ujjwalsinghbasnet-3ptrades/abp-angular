using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace AbpPoc.Documents
{
    public abstract class DocumentsAppServiceTests<TStartupModule> : AbpPocApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IDocumentsAppService _documentsAppService;
        private readonly IRepository<Document, Guid> _documentRepository;

        public DocumentsAppServiceTests()
        {
            _documentsAppService = GetRequiredService<IDocumentsAppService>();
            _documentRepository = GetRequiredService<IRepository<Document, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _documentsAppService.GetListAsync(new GetDocumentsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("1e1323f6-98fe-4418-918b-f578cdaef905")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("274aff91-85b8-492a-868a-5f73710f85df")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _documentsAppService.GetAsync(Guid.Parse("1e1323f6-98fe-4418-918b-f578cdaef905"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("1e1323f6-98fe-4418-918b-f578cdaef905"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new DocumentCreateDto
            {
                name = "e6841968ecbd43af9733c9bcf9cca52e0d744af930c34118805aa504284ae8c2b7102a7",
                size = 1805557191,
                type = "889c489ca5524197b125"
            };

            // Act
            var serviceResult = await _documentsAppService.CreateAsync(input);

            // Assert
            var result = await _documentRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.name.ShouldBe("e6841968ecbd43af9733c9bcf9cca52e0d744af930c34118805aa504284ae8c2b7102a7");
            result.size.ShouldBe(1805557191);
            result.type.ShouldBe("889c489ca5524197b125");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new DocumentUpdateDto()
            {
                name = "89ca4c269bc5435b8bc470c7d5c2c6f5a8723669ec1249519ad790935b786bf998fce42f3a3d4faab8f",
                size = 315730284,
                type = "751af5770d0c408db43527340bec62dea"
            };

            // Act
            var serviceResult = await _documentsAppService.UpdateAsync(Guid.Parse("1e1323f6-98fe-4418-918b-f578cdaef905"), input);

            // Assert
            var result = await _documentRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.name.ShouldBe("89ca4c269bc5435b8bc470c7d5c2c6f5a8723669ec1249519ad790935b786bf998fce42f3a3d4faab8f");
            result.size.ShouldBe(315730284);
            result.type.ShouldBe("751af5770d0c408db43527340bec62dea");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _documentsAppService.DeleteAsync(Guid.Parse("1e1323f6-98fe-4418-918b-f578cdaef905"));

            // Assert
            var result = await _documentRepository.FindAsync(c => c.Id == Guid.Parse("1e1323f6-98fe-4418-918b-f578cdaef905"));

            result.ShouldBeNull();
        }
    }
}