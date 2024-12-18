using Volo.Abp.Settings;

namespace AbpPoc.Settings;

public class AbpPocSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpPocSettings.MySetting1));
    }
}
