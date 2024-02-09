using Volo.Abp.Modularity;

namespace FileUploader;

[DependsOn(
    typeof(FileUploaderApplicationModule),
    typeof(FileUploaderDomainTestModule)
)]
public class FileUploaderApplicationTestModule : AbpModule
{

}
