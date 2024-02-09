using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FileUploader.UploadFiles
{
    public abstract class UploadFileCreateDtoBase
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public string? FileSize { get; set; }
    }
}