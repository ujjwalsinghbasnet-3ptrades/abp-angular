using AbpPoc.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpPoc.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpPocController : AbpControllerBase
{
    protected AbpPocController()
    {
        LocalizationResource = typeof(AbpPocResource);
    }
}
