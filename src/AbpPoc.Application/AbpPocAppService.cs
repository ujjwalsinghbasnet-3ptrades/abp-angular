using AbpPoc.Localization;
using Volo.Abp.Application.Services;

namespace AbpPoc;

/* Inherit your application services from this class.
 */
public abstract class AbpPocAppService : ApplicationService
{
    protected AbpPocAppService()
    {
        LocalizationResource = typeof(AbpPocResource);
    }
}
