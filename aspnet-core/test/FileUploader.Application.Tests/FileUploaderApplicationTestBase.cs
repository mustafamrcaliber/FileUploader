using Volo.Abp.Modularity;

namespace FileUploader;

public abstract class FileUploaderApplicationTestBase<TStartupModule> : FileUploaderTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
