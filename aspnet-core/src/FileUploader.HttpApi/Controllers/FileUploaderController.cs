using FileUploader.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FileUploader.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FileUploaderController : AbpControllerBase
{
    protected FileUploaderController()
    {
        LocalizationResource = typeof(FileUploaderResource);
    }
}
