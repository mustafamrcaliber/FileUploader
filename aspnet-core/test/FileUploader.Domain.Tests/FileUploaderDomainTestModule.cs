using Volo.Abp.Modularity;

namespace FileUploader;

[DependsOn(
    typeof(FileUploaderDomainModule),
    typeof(FileUploaderTestBaseModule)
)]
public class FileUploaderDomainTestModule : AbpModule
{

}
