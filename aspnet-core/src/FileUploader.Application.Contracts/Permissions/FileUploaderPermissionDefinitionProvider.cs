using FileUploader.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace FileUploader.Permissions;

public class FileUploaderPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FileUploaderPermissions.GroupName);

        myGroup.AddPermission(FileUploaderPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(FileUploaderPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(FileUploaderPermissions.MyPermission1, L("Permission:MyPermission1"));

        var uploadFilePermission = myGroup.AddPermission(FileUploaderPermissions.UploadFiles.Default, L("Permission:UploadFiles"));
        uploadFilePermission.AddChild(FileUploaderPermissions.UploadFiles.Create, L("Permission:Create"));
        uploadFilePermission.AddChild(FileUploaderPermissions.UploadFiles.Edit, L("Permission:Edit"));
        uploadFilePermission.AddChild(FileUploaderPermissions.UploadFiles.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FileUploaderResource>(name);
    }
}