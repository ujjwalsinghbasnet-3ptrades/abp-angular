using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace AbpPoc.PartTests
{
    public abstract class PartTestManagerBase : DomainService
    {
        protected IPartTestRepository _partTestRepository;

        public PartTestManagerBase(IPartTestRepository partTestRepository)
        {
            _partTestRepository = partTestRepository;
        }

        public virtual async Task<PartTest> CreateAsync(
        string partNumber, string name, string cageCode, string distributionStatement, string? toNumber = null, string? smr = null, string? niin = null, string? fsc = null, string? wuc = null, string? uoc = null, string? uniqueId = null, string? nsn = null, string? imageUrl = null)
        {
            Check.NotNullOrWhiteSpace(partNumber, nameof(partNumber));
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(cageCode, nameof(cageCode));
            Check.NotNullOrWhiteSpace(distributionStatement, nameof(distributionStatement));

            var partTest = new PartTest(
             GuidGenerator.Create(),
             partNumber, name, cageCode, distributionStatement, toNumber, smr, niin, fsc, wuc, uoc, uniqueId, nsn, imageUrl
             );

            return await _partTestRepository.InsertAsync(partTest);
        }

        public virtual async Task<PartTest> UpdateAsync(
            Guid id,
            string partNumber, string name, string cageCode, string distributionStatement, string? toNumber = null, string? smr = null, string? niin = null, string? fsc = null, string? wuc = null, string? uoc = null, string? uniqueId = null, string? nsn = null, string? imageUrl = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(partNumber, nameof(partNumber));
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(cageCode, nameof(cageCode));
            Check.NotNullOrWhiteSpace(distributionStatement, nameof(distributionStatement));

            var partTest = await _partTestRepository.GetAsync(id);

            partTest.partNumber = partNumber;
            partTest.name = name;
            partTest.cageCode = cageCode;
            partTest.distributionStatement = distributionStatement;
            partTest.toNumber = toNumber;
            partTest.smr = smr;
            partTest.niin = niin;
            partTest.fsc = fsc;
            partTest.wuc = wuc;
            partTest.uoc = uoc;
            partTest.uniqueId = uniqueId;
            partTest.nsn = nsn;
            partTest.imageUrl = imageUrl;

            partTest.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _partTestRepository.UpdateAsync(partTest);
        }

    }
}