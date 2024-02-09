using System.Threading.Tasks;

namespace FileUploader.Data;

public interface IFileUploaderDbSchemaMigrator
{
    Task MigrateAsync();
}
