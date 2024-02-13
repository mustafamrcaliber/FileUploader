using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploader.FileUploaderSaver
{
    public interface IFileUploaderSaverAppService
    {
        public  Task<UploadFileResponseModel> UploadFile(UploadFileRequestModel FileData);
        public List<GetWholeDirectorySturctureResponseModel> GetWholeDirectorySturcture();
        public  Task<List<string>> GetListOfFilesFromDir();
        public Task<string> UploadFileToChat(string FileName);
        public Task<string> SendUserMessageToApiAndGetJsonChart(string Message);
        public Task<string> SendUserMessageToApi(string Message);
        public string GetUrlToUploadFile();
    }
}