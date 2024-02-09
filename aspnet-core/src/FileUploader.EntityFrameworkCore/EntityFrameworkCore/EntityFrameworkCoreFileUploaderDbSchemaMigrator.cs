using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FileUploader.Data;
using Volo.Abp.DependencyInjection;

namespace FileUploader.EntityFrameworkCore;

public class EntityFrameworkCoreFileUploaderDbSchemaMigrator
    : IFileUploaderDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreFileUploaderDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the FileUploaderDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<FileUploaderDbContext>()
            .Database
            .MigrateAsync();
    }
}
