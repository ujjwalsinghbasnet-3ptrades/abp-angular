using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace AbpPoc.Documents
{
    public abstract class DocumentManagerBase : DomainService
    {
        protected IDocumentRepository _documentRepository;

        public DocumentManagerBase(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public virtual async Task<Document> CreateAsync(
        string name, int size, string? type = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var document = new Document(
             GuidGenerator.Create(),
             name, size, type
             );

            return await _documentRepository.InsertAsync(document);
        }

        public virtual async Task<Document> UpdateAsync(
            Guid id,
            string name, int size, string? type = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var document = await _documentRepository.GetAsync(id);

            document.name = name;
            document.size = size;
            document.type = type;

            document.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _documentRepository.UpdateAsync(document);
        }

    }
}