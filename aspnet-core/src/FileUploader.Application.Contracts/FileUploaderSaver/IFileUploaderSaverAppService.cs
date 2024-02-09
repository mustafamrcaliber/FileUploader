using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploader.FileUploaderSaver
{
    public interface IFileUploaderSaverAppService
    {
        public  Task<UploadFileResponseModel> UploadFile(UploadFileRequestModel FileData);
        public List<GetWholeDirectorySturctureResponseModel> GetWholeDirectorySturcture();
    }
}