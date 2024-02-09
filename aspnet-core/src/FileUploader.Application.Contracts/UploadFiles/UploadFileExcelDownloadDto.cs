using Volo.Abp.Application.Dtos;
using System;

namespace FileUploader.UploadFiles
{
    public abstract class UploadFileExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public string? FileSize { get; set; }

        public UploadFileExcelDownloadDtoBase()
        {

        }
    }
}