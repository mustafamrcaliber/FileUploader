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

namespace FileUploader.ModelRegistrations
{
    public abstract class EfCoreModelRegistrationRepositoryBase : EfCoreRepository<FileUploaderDbContext, ModelRegistration, Guid>
    {
        public EfCoreModelRegistrationRepositoryBase(IDbContextProvider<FileUploaderDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<ModelRegistration>> GetListAsync(
            string? filterText = null,
            int? modelMin = null,
            int? modelMax = null,
            string? apiPath = null,
            string? localPath = null,
            int? scheduleMin = null,
            int? scheduleMax = null,
            double? intervalMin = null,
            double? intervalMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, modelMin, modelMax, apiPath, localPath, scheduleMin, scheduleMax, intervalMin, intervalMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ModelRegistrationConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? modelMin = null,
            int? modelMax = null,
            string? apiPath = null,
            string? localPath = null,
            int? scheduleMin = null,
            int? scheduleMax = null,
            double? intervalMin = null,
            double? intervalMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, modelMin, modelMax, apiPath, localPath, scheduleMin, scheduleMax, intervalMin, intervalMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ModelRegistration> ApplyFilter(
            IQueryable<ModelRegistration> query,
            string? filterText = null,
            int? modelMin = null,
            int? modelMax = null,
            string? apiPath = null,
            string? localPath = null,
            int? scheduleMin = null,
            int? scheduleMax = null,
            double? intervalMin = null,
            double? intervalMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ApiPath!.Contains(filterText!) || e.LocalPath!.Contains(filterText!))
                    .WhereIf(modelMin.HasValue, e => e.Model >= modelMin!.Value)
                    .WhereIf(modelMax.HasValue, e => e.Model <= modelMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(apiPath), e => e.ApiPath.Contains(apiPath))
                    .WhereIf(!string.IsNullOrWhiteSpace(localPath), e => e.LocalPath.Contains(localPath))
                    .WhereIf(scheduleMin.HasValue, e => e.Schedule >= scheduleMin!.Value)
                    .WhereIf(scheduleMax.HasValue, e => e.Schedule <= scheduleMax!.Value)
                    .WhereIf(intervalMin.HasValue, e => e.Interval >= intervalMin!.Value)
                    .WhereIf(intervalMax.HasValue, e => e.Interval <= intervalMax!.Value);
        }
    }
}