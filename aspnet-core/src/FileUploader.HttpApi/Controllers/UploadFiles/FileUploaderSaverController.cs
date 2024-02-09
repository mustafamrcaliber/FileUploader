using System;
using System.Threading.Tasks;
using FileUploader.Controllers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Net.Http.Headers;

namespace FileUploader.FileUploaderSaver
{
    [Route("[controller]")]
    public class FileUploaderSaverController : FileUploaderController
    {
        private readonly IFileUploaderSaverAppService _iFileUploaderSaverAppService;

        public FileUploaderSaverController(
            IFileUploaderSaverAppService iFileUploaderSaverAppService
        )
        {
            _iFileUploaderSaverAppService = iFileUploaderSaverAppService;
        }

        [HttpPost("UploadFile")]
        [DisableRequestSizeLimit]
        public async Task<UploadFileResponseModel> UploadFile(
            [FromForm] UploadFileRequestModel FileData
        )
        {
            try
            {
                return await _iFileUploaderSaverAppService.UploadFile(FileData);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("GetWholeDirectorySturcture")]
        public List<GetWholeDirectorySturctureResponseModel> GetWholeDirectorySturcture()
        {
            try
            {
                return _iFileUploaderSaverAppService.GetWholeDirectorySturcture();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        [HttpGet("DownloadDocument")]
        public  async Task<FileStream>  DownloadDocument(string FolderName, string FileName)
        {
            string filePath = $@"{Directory.GetCurrentDirectory()}\Files\{FolderName}\{FileName}";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            // return File(fileBytes, "application/force-download", FileName);

            return  new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }
    }
}
