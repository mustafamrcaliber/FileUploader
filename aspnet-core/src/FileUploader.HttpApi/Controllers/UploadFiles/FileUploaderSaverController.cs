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

        [AllowAnonymous]
        [HttpGet("GetListOfFilesFromDir")]
        public async Task<List<string>> GetListOfFilesFromDir()
        {
            List<string> Response = new List<string>();
            try
            {
                Response = await _iFileUploaderSaverAppService.GetListOfFilesFromDir();
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
            return Response;
        }

        [AllowAnonymous]
        [HttpGet("UploadFileToChat")]
        public async Task<string> UploadFileToChat(string FileName)
        {
            string Response = "";
            try
            {
                Response = await _iFileUploaderSaverAppService.UploadFileToChat(FileName);
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
            return Response;
        }

        [AllowAnonymous]
        [HttpGet("SendUserMessageToApiAndGetJsonChart")]
        public async Task<string> SendUserMessageToApiAndGetJsonChart(string Message)
        {
            string Response = "";
            try
            {
                Response = await _iFileUploaderSaverAppService.SendUserMessageToApiAndGetJsonChart(Message);
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
            return Response;
        }

        [AllowAnonymous]
        [HttpGet("SendUserMessageToApi")]
        public async Task<string> SendUserMessageToApi(string Message)
        {
            string Response = "";
            try
            {
                Response = await _iFileUploaderSaverAppService.SendUserMessageToApi(Message);
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
            return Response;
        }
        [AllowAnonymous]
        [HttpGet("GetUrlToUploadFile")]
        public string GetUrlToUploadFile()
        {
            string Response = "";
            try
            {
                Response = _iFileUploaderSaverAppService.GetUrlToUploadFile();
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
            return Response;
        }

        [AllowAnonymous]
        [HttpGet("GetPMSampleData")]
        public async Task<List<GetPMSampleDataResponse>> GetPMSampleData()
        {
            List<GetPMSampleDataResponse> Response = new List<GetPMSampleDataResponse>();
            try
            {
                Response = await _iFileUploaderSaverAppService.GetPMSampleData();
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
            return Response;
        }

        [AllowAnonymous]
        [HttpGet("GetEmSampleData")]
        public async Task<List<GetEmSampleDataResponse>> GetEmSampleData()
        {
            List<GetEmSampleDataResponse> Response = new List<GetEmSampleDataResponse>();
            try
            {
                Response = await _iFileUploaderSaverAppService.GetEmSampleData();
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
            return Response;
        }
    }
}
