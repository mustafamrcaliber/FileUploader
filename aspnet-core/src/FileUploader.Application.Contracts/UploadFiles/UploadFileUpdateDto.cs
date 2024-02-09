using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace FileUploader.UploadFiles
{
    public abstract class UploadFileUpdateDtoBase : IHasConcurrencyStamp
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public string? FileSize { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}