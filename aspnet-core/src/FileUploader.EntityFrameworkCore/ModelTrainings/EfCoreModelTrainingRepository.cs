using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using FileUploader.EntityFrameworkCore;

namespace FileUploader.ModelTrainings
{
    public abstract class EfCoreModelTrainingRepositoryBase : EfCoreRepository<FileUploaderDbContext, ModelTraining, Guid>
    {
        public EfCoreModelTrainingRepositoryBase(IDbContextProvider<FileUploaderDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<ModelTraining>> GetListAsync(
            string? filterText = null,
            int? typeMin = null,
            int? typeMax = null,
            string? path = null,
            int? dataSourceMin = null,
            int? dataSourceMax = null,
            string? databaseConnectionString = null,
            string? documentsDirectoryPath = null,
            int? modeMin = null,
            int? modeMax = null,
            string? trainingLog = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, typeMin, typeMax, path, dataSourceMin, dataSourceMax, databaseConnectionString, documentsDirectoryPath, modeMin, modeMax, trainingLog);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ModelTrainingConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? typeMin = null,
            int? typeMax = null,
            string? path = null,
            int? dataSourceMin = null,
            int? dataSourceMax = null,
            string? databaseConnectionString = null,
            string? documentsDirectoryPath = null,
            int? modeMin = null,
            int? modeMax = null,
            string? trainingLog = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, typeMin, typeMax, path, dataSourceMin, dataSourceMax, databaseConnectionString, documentsDirectoryPath, modeMin, modeMax, trainingLog);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ModelTraining> ApplyFilter(
            IQueryable<ModelTraining> query,
            string? filterText = null,
            int? typeMin = null,
            int? typeMax = null,
            string? path = null,
            int? dataSourceMin = null,
            int? dataSourceMax = null,
            string? databaseConnectionString = null,
            string? documentsDirectoryPath = null,
            int? modeMin = null,
            int? modeMax = null,
            string? trainingLog = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Path!.Contains(filterText!) || e.DatabaseConnectionString!.Contains(filterText!) || e.DocumentsDirectoryPath!.Contains(filterText!) || e.TrainingLog!.Contains(filterText!))
                    .WhereIf(typeMin.HasValue, e => e.Type >= typeMin!.Value)
                    .WhereIf(typeMax.HasValue, e => e.Type <= typeMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(path), e => e.Path.Contains(path))
                    .WhereIf(dataSourceMin.HasValue, e => e.DataSource >= dataSourceMin!.Value)
                    .WhereIf(dataSourceMax.HasValue, e => e.DataSource <= dataSourceMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(databaseConnectionString), e => e.DatabaseConnectionString.Contains(databaseConnectionString))
                    .WhereIf(!string.IsNullOrWhiteSpace(documentsDirectoryPath), e => e.DocumentsDirectoryPath.Contains(documentsDirectoryPath))
                    .WhereIf(modeMin.HasValue, e => e.Mode >= modeMin!.Value)
                    .WhereIf(modeMax.HasValue, e => e.Mode <= modeMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(trainingLog), e => e.TrainingLog.Contains(trainingLog));
        }
    }
}