using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace AbpPoc.PartTests
{
    public class PartTest : PartTestBase
    {
        //<suite-custom-code-autogenerated>
        protected PartTest()
        {

        }

        public PartTest(Guid id, string partNumber, string name, string cageCode, string distributionStatement, string? toNumber = null, string? smr = null, string? niin = null, string? fsc = null, string? wuc = null, string? uoc = null, string? uniqueId = null, string? nsn = null, string? imageUrl = null)
            : base(id, partNumber, name, cageCode, distributionStatement, toNumber, smr, niin, fsc, wuc, uoc, uniqueId, nsn, imageUrl)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}