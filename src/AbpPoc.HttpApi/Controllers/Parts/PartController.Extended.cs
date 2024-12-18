using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using AbpPoc.Parts;

namespace AbpPoc.Controllers.Parts
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Part")]
    [Route("api/app/parts")]

    public class PartController : PartControllerBase, IPartsAppService
    {
        public PartController(IPartsAppService partsAppService) : base(partsAppService)
        {
        }
    }
}