using FileUploader.Localization;
using Volo.Abp.Application.Services;

namespace FileUploader;

/* Inherit your application services from this class.
 */
public abstract class FileUploaderAppService : ApplicationService
{
    protected FileUploaderAppService()
    {
        LocalizationResource = typeof(FileUploaderResource);
    }
}
