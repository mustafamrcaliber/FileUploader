using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using FileUploader.Shared;

namespace FileUploader.UploadFiles
{
    public partial interface IUploadFilesAppService : IApplicationService
    {

        Task<PagedResultDto<UploadFileDto>> GetListAsync(GetUploadFilesInput input);

        Task<UploadFileDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<UploadFileDto> CreateAsync(UploadFileCreateDto input);

        Task<UploadFileDto> UpdateAsync(Guid id, UploadFileUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(UploadFileExcelDownloadDto input);

        Task<FileUploader.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}