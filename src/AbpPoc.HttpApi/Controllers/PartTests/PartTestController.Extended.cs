using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using AbpPoc.PartTests;

namespace AbpPoc.Controllers.PartTests
{
    [RemoteService]
    [Area("app")]
    [ControllerName("PartTest")]
    [Route("api/app/part-tests")]

    public class PartTestController : PartTestControllerBase, IPartTestsAppService
    {
        public PartTestController(IPartTestsAppService partTestsAppService) : base(partTestsAppService)
        {
        }
    }
}