using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FileUploader;

[Dependency(ReplaceServices = true)]
public class FileUploaderBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CaliGen";
}
