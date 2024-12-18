using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace AbpPoc.Parts
{
    public abstract class PartManagerBase : DomainService
    {
        protected IPartRepository _partRepository;

        public PartManagerBase(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        public virtual async Task<Part> CreateAsync(
        string name, string partNumber, string cageCode, string toNumber, string nsn, string? description = null, string? distributionStatement = null, string? smr = null, string? niin = null, string? fsc = null, string? wuc = null, string? uoc = null, string? uniqueId = null, string? imageUrl = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), int.MaxValue, PartConsts.nameMinLength);
            Check.NotNullOrWhiteSpace(partNumber, nameof(partNumber));
            Check.NotNullOrWhiteSpace(cageCode, nameof(cageCode));
            Check.NotNullOrWhiteSpace(toNumber, nameof(toNumber));
            Check.NotNullOrWhiteSpace(nsn, nameof(nsn));

            var part = new Part(
             GuidGenerator.Create(),
             name, partNumber, cageCode, toNumber, nsn, description, distributionStatement, smr, niin, fsc, wuc, uoc, uniqueId, imageUrl
             );

            return await _partRepository.InsertAsync(part);
        }

        public virtual async Task<Part> UpdateAsync(
            Guid id,
            string name, string partNumber, string cageCode, string toNumber, string nsn, string? description = null, string? distributionStatement = null, string? smr = null, string? niin = null, string? fsc = null, string? wuc = null, string? uoc = null, string? uniqueId = null, string? imageUrl = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), int.MaxValue, PartConsts.nameMinLength);
            Check.NotNullOrWhiteSpace(partNumber, nameof(partNumber));
            Check.NotNullOrWhiteSpace(cageCode, nameof(cageCode));
            Check.NotNullOrWhiteSpace(toNumber, nameof(toNumber));
            Check.NotNullOrWhiteSpace(nsn, nameof(nsn));

            var part = await _partRepository.GetAsync(id);

            part.name = name;
            part.partNumber = partNumber;
            part.cageCode = cageCode;
            part.toNumber = toNumber;
            part.nsn = nsn;
            part.description = description;
            part.distributionStatement = distributionStatement;
            part.smr = smr;
            part.niin = niin;
            part.fsc = fsc;
            part.wuc = wuc;
            part.uoc = uoc;
            part.uniqueId = uniqueId;
            part.imageUrl = imageUrl;

            part.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _partRepository.UpdateAsync(part);
        }

    }
}