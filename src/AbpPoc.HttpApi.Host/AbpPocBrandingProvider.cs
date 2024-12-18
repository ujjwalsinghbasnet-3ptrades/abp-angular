using Microsoft.Extensions.Localization;
using AbpPoc.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpPoc;

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
