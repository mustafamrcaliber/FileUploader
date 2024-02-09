using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
namespace FileUploader.FileUploaderSaver
{
    public class UploadFileRequestModel
    {
        public string FilePath { get; set; }
        public IFormFile File { get; set; }
    }

    public class UploadFileResponseModel
    {
        public int FileUploadStatus { get; set; }
        public string ErrorMessage { get; set; } = "--";
        public string SuccessMessage { get; set; } = "--";
        public string? FileName { get; set; } = "--";
    }
    public class GetWholeDirectorySturctureResponseModel
    {
        public string FolderName { get; set; }
        public List<string> FileName { get; set; }
    }
}
