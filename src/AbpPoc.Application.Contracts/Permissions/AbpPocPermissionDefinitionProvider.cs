using AbpPoc.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace AbpPoc.Permissions;

public class AbpPocPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpPocPermissions.GroupName);

        myGroup.AddPermission(AbpPocPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(AbpPocPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        var booksPermission = myGroup.AddPermission(AbpPocPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(AbpPocPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(AbpPocPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(AbpPocPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpPocPermissions.MyPermission1, L("Permission:MyPermission1"));

        var partPermission = myGroup.AddPermission(AbpPocPermissions.Parts.Default, L("Permission:Parts"));
        partPermission.AddChild(AbpPocPermissions.Parts.Create, L("Permission:Create"));
        partPermission.AddChild(AbpPocPermissions.Parts.Edit, L("Permission:Edit"));
        partPermission.AddChild(AbpPocPermissions.Parts.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpPocResource>(name);
    }
}