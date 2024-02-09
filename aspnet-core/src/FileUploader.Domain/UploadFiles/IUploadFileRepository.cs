using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FileUploader.UploadFiles
{
    public partial interface IUploadFileRepository : IRepository<UploadFile, Guid>
    {
        Task<List<UploadFile>> GetListAsync(
            string? filterText = null,
            string? fileName = null,
            string? filePath = null,
            string? fileType = null,
            string? fileSize = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? fileName = null,
            string? filePath = null,
            string? fileType = null,
            string? fileSize = null,
            CancellationToken cancellationToken = default);
    }
}