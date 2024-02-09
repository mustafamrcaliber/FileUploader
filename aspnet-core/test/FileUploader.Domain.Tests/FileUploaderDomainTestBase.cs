using Volo.Abp.Modularity;

namespace FileUploader;

/* Inherit from this class for your domain layer tests. */
public abstract class FileUploaderDomainTestBase<TStartupModule> : FileUploaderTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
