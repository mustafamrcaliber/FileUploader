using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using FileUploader.UploadFiles;
using Volo.Abp.Content;
using FileUploader.Shared;

namespace FileUploader.Controllers.UploadFiles
{
    [RemoteService]
    [Area("app")]
    [ControllerName("UploadFile")]
    [Route("api/app/upload-files")]

    public abstract class UploadFileControllerBase : AbpController
    {
        protected IUploadFilesAppService _uploadFilesAppService;

        public UploadFileControllerBase(IUploadFilesAppService uploadFilesAppService)
        {
            _uploadFilesAppService = uploadFilesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<UploadFileDto>> GetListAsync(GetUploadFilesInput input)
        {
            return _uploadFilesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UploadFileDto> GetAsync(Guid id)
        {
            return _uploadFilesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<UploadFileDto> CreateAsync(UploadFileCreateDto input)
        {
            return _uploadFilesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UploadFileDto> UpdateAsync(Guid id, UploadFileUpdateDto input)
        {
            return _uploadFilesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _uploadFilesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(UploadFileExcelDownloadDto input)
        {
            return _uploadFilesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<FileUploader.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _uploadFilesAppService.GetDownloadTokenAsync();
        }
    }
}