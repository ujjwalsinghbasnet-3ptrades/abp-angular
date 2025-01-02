using AbpPoc.Shared;
using AbpPoc.Parts;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using AbpPoc.Permissions;
using AbpPoc.Ipbs;

namespace AbpPoc.Ipbs
{
    public class IpbsAppService : IpbsAppServiceBase, IIpbsAppService
    {
        //<suite-custom-code-autogenerated>
        public IpbsAppService(IIpbRepository ipbRepository, IpbManager ipbManager, IRepository<AbpPoc.Parts.Part, Guid> partRepository)
            : base(ipbRepository, ipbManager, partRepository)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}