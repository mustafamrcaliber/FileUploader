using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using FileUploader.Permissions;
using FileUploader.UploadFiles;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using FileUploader.Shared;

namespace FileUploader.UploadFiles
{
    [RemoteService(IsEnabled = false)]
    [Authorize(FileUploaderPermissions.UploadFiles.Default)]
    public abstract class UploadFilesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<UploadFileExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IUploadFileRepository _uploadFileRepository;
        protected UploadFileManager _uploadFileManager;

        public UploadFilesAppServiceBase(IUploadFileRepository uploadFileRepository, UploadFileManager uploadFileManager, IDistributedCache<UploadFileExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _uploadFileRepository = uploadFileRepository;
            _uploadFileManager = uploadFileManager;
        }

        public virtual async Task<PagedResultDto<UploadFileDto>> GetListAsync(GetUploadFilesInput input)
        {
            var totalCount = await _uploadFileRepository.GetCountAsync(input.FilterText, input.FileName, input.FilePath, input.FileType, input.FileSize);
            var items = await _uploadFileRepository.GetListAsync(input.FilterText, input.FileName, input.FilePath, input.FileType, input.FileSize, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<UploadFileDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<UploadFile>, List<UploadFileDto>>(items)
            };
        }

        public virtual async Task<UploadFileDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<UploadFile, UploadFileDto>(await _uploadFileRepository.GetAsync(id));
        }

        [Authorize(FileUploaderPermissions.UploadFiles.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _uploadFileRepository.DeleteAsync(id);
        }

        [Authorize(FileUploaderPermissions.UploadFiles.Create)]
        public virtual async Task<UploadFileDto> CreateAsync(UploadFileCreateDto input)
        {

            var uploadFile = await _uploadFileManager.CreateAsync(
            input.FileName, input.FilePath, input.FileType, input.FileSize
            );

            return ObjectMapper.Map<UploadFile, UploadFileDto>(uploadFile);
        }

        [Authorize(FileUploaderPermissions.UploadFiles.Edit)]
        public virtual async Task<UploadFileDto> UpdateAsync(Guid id, UploadFileUpdateDto input)
        {

            var uploadFile = await _uploadFileManager.UpdateAsync(
            id,
            input.FileName, input.FilePath, input.FileType, input.FileSize, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<UploadFile, UploadFileDto>(uploadFile);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(UploadFileExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _uploadFileRepository.GetListAsync(input.FilterText, input.FileName, input.FilePath, input.FileType, input.FileSize);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<UploadFile>, List<UploadFileExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "UploadFiles.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<FileUploader.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new UploadFileExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new FileUploader.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}