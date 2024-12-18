using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using AbpPoc.Localization;

namespace AbpPoc.Web.Public;

[Dependency(ReplaceServices = true)]
public class AbpPocBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AbpPocResource> _localizer;

    public AbpPocBrandingProvider(IStringLocalizer<AbpPocResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
