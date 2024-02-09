using System;

namespace FileUploader.UploadFiles;

public abstract class UploadFileExcelDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}