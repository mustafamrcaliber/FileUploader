using System;

namespace FileUploader.UploadFiles
{
    public abstract class UploadFileExcelDtoBase
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public string? FileSize { get; set; }
    }
}