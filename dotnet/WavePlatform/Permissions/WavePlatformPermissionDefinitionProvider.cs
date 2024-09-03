using WavePlatform.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace WavePlatform.Permissions;

public class WavePlatformPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(WavePlatformPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(WavePlatformPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(WavePlatformPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(WavePlatformPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(WavePlatformPermissions.Books.Delete, L("Permission:Books.Delete"));
        
        //Define your own permissions here. Example:
        //myGroup.AddPermission(WavePlatformPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<WavePlatformResource>(name);
    }
}
