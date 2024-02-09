using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using FileUploader.UploadFiles;

namespace FileUploader.Controllers.UploadFiles
{
    [RemoteService]
    [Area("app")]
    [ControllerName("UploadFile")]
    [Route("api/app/upload-files")]

    public class UploadFileController : UploadFileControllerBase, IUploadFilesAppService
    {
        public UploadFileController(IUploadFilesAppService uploadFilesAppService) : base(uploadFilesAppService)
        {
        }
    }
}