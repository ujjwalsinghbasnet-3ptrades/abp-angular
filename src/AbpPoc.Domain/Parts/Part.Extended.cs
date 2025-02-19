using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace AbpPoc.Parts
{
    public class Part : PartBase
    {
        //<suite-custom-code-autogenerated>
        protected Part()
        {

        }

        public Part(Guid id, string name, string partNumber, string cageCode, string toNumber, string nsn, string? description = null, string? distributionStatement = null, string? smr = null, string? niin = null, string? fsc = null, string? wuc = null, string? uoc = null, string? uniqueId = null, string? imageUrl = null)
            : base(id, name, partNumber, cageCode, toNumber, nsn, description, distributionStatement, smr, niin, fsc, wuc, uoc, uniqueId, imageUrl)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}