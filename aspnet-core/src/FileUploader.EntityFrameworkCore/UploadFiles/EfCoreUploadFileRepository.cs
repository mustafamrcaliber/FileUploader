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

namespace FileUploader.UploadFiles
{
    public abstract class EfCoreUploadFileRepositoryBase : EfCoreRepository<FileUploaderDbContext, UploadFile, Guid>
    {
        public EfCoreUploadFileRepositoryBase(IDbContextProvider<FileUploaderDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<UploadFile>> GetListAsync(
            string? filterText = null,
            string? fileName = null,
            string? filePath = null,
            string? fileType = null,
            string? fileSize = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, fileName, filePath, fileType, fileSize);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? UploadFileConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? fileName = null,
            string? filePath = null,
            string? fileType = null,
            string? fileSize = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, fileName, filePath, fileType, fileSize);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<UploadFile> ApplyFilter(
            IQueryable<UploadFile> query,
            string? filterText = null,
            string? fileName = null,
            string? filePath = null,
            string? fileType = null,
            string? fileSize = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.FileName!.Contains(filterText!) || e.FilePath!.Contains(filterText!) || e.FileType!.Contains(filterText!) || e.FileSize!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(fileName), e => e.FileName.Contains(fileName))
                    .WhereIf(!string.IsNullOrWhiteSpace(filePath), e => e.FilePath.Contains(filePath))
                    .WhereIf(!string.IsNullOrWhiteSpace(fileType), e => e.FileType.Contains(fileType))
                    .WhereIf(!string.IsNullOrWhiteSpace(fileSize), e => e.FileSize.Contains(fileSize));
        }
    }
}