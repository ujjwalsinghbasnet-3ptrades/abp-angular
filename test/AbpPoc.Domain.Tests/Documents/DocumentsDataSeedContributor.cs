using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using AbpPoc.Documents;

namespace AbpPoc.Documents
{
    public class DocumentsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IDocumentRepository _documentRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public DocumentsDataSeedContributor(IDocumentRepository documentRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _documentRepository = documentRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _documentRepository.InsertAsync(new Document
            (
                id: Guid.Parse("1e1323f6-98fe-4418-918b-f578cdaef905"),
                name: "173b1b991c994c969dca57cf4d64133ddd586784ca6a44d287b058f3899307976154a695a77740d5b067545af08c33",
                size: 492089424,
                type: "a5d65e2793ba4afaa65d975ab911c"
            ));

            await _documentRepository.InsertAsync(new Document
            (
                id: Guid.Parse("274aff91-85b8-492a-868a-5f73710f85df"),
                name: "fd26b578a7904032bde32dcbfaafd4c52d7565f211",
                size: 60897857,
                type: "5534f0cecfc843db9ca9e2"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}