using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FileUploader.Data;

/* This is used if database provider does't define
 * IFileUploaderDbSchemaMigrator implementation.
 */
public class NullFileUploaderDbSchemaMigrator : IFileUploaderDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
