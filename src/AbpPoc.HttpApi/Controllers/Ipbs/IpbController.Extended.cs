using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using AbpPoc.Ipbs;

namespace AbpPoc.Controllers.Ipbs
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Ipb")]
    [Route("api/app/ipbs")]

    public class IpbController : IpbControllerBase, IIpbsAppService
    {
        public IpbController(IIpbsAppService ipbsAppService) : base(ipbsAppService)
        {
        }
    }
}