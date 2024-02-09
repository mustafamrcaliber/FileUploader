using Volo.Abp.Application.Dtos;
using System;

namespace FileUploader.UploadFiles
{
    public abstract class GetUploadFilesInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public string? FileSize { get; set; }

        public GetUploadFilesInputBase()
        {

        }
    }
}