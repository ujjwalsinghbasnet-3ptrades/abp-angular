using AbpPoc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpPoc.Web.Public.Pages;

/* Inherit your Page Model classes from this class.
 */
public abstract class AbpPocPublicPageModel : AbpPageModel
{
    protected AbpPocPublicPageModel()
    {
        LocalizationResourceType = typeof(AbpPocResource);
    }
}
