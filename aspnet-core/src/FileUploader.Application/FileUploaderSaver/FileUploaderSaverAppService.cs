using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FileUploader.UploadFiles;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Content;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Claims;
using System.Net.Http;

namespace FileUploader.FileUploaderSaver
{
    public class FileUploaderSaverAppService : FileUploaderAppService, IFileUploaderSaverAppService
    {
        private readonly IUploadFileRepository _iUploadFileRepository;
        private readonly HttpClient client = new HttpClient();
    //     [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    // public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        
        public FileUploaderSaverAppService(IUploadFileRepository iUploadFileRepository)
        {
            _iUploadFileRepository = iUploadFileRepository;
        }
        public async Task<UploadFileResponseModel> UploadFile(UploadFileRequestModel FileData)
        {
            Guid guid = Guid.NewGuid();
            string guidFolder = guid.ToString();
            Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\Files\{guidFolder}");
            var FilePath = Path.Combine($@"{Directory.GetCurrentDirectory()}\Files\{guidFolder}\{Path.GetFileName(FileData.File.FileName)}");
           // var SharedDirectoryPath = $@"\\cqmsinnpoc2\Shared\docs\{Path.GetFileName(FileData.File.FileName)}";
            using (var fileSteam = new FileStream(FilePath, FileMode.Create))
            {
                await FileData.File.CopyToAsync(fileSteam);

                using (var client = new HttpClient())
    {
        using (var content = new MultipartFormDataContent())
        {
            content.Add(new StringContent(FileData.FilePath.ToString()), "FilePath");
            content.Add(new StreamContent(FileData.File.OpenReadStream()), "File", FileData.File.FileName);  


            var requestUri = @"http://10.20.61.83:5000/api/FileSaver/UploadFile";
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = content };
            var result = await client.SendAsync(request);
        }

    }

                await _iUploadFileRepository.InsertAsync(new UploadFile
            (
                id: guid,
                fileName: Path.GetFileName(FileData.File.FileName),
                filePath: FilePath,
                fileType: Path.GetExtension(FileData.File.FileName),
                fileSize: FileData.File.Length.ToString()
            ));
            }
        //      IntPtr tokenHandle = new IntPtr(0);
        // tokenHandle = IntPtr.Zero;

        // bool returnValue = LogonUser("USerName", "DomainName", "password", 2, 0, ref tokenHandle);
        // WindowsIdentity ImpersonatedIdentity = new WindowsIdentity(tokenHandle);
        // WindowsImpersonationContext MyImpersonation = ImpersonatedIdentity.Impersonate();

            // using (var fileSteam = new FileStream(SharedDirectoryPath, FileMode.Create))
            // {
            //     await FileData.File.CopyToAsync(fileSteam);
                
            // }
            ///
            /// sendinf file to other port 
            /// 

            // string UrlForFileSaving = @"http://10.20.58.2:5000/api/FileSaver/UploadFile";
            // var content = new MultipartFormDataContent();
            // content.Add(new StringContent(FileData.FilePath.ToString()), "Id");
            // content.Add(new StringContent(FileData.File), "Id");
            // HttpResponseMessage res = await client.PostAsync(UrlForFileSaving, content);

            

            //content.Add(new StringContent(FileData.File), "Id");
            ///
            return new UploadFileResponseModel(){
                FileUploadStatus = 1,
                SuccessMessage = "uploaded",
                ErrorMessage = "--",
                FileName = FileData.File.FileName.ToString()
            };
        }
        public List<GetWholeDirectorySturctureResponseModel> GetWholeDirectorySturcture()
        {
            List<GetWholeDirectorySturctureResponseModel> response = new List<GetWholeDirectorySturctureResponseModel>();
            string GetCurrentDirectory = $@"{Directory.GetCurrentDirectory()}\Files\";
            string[] folders = System.IO.Directory.GetDirectories(GetCurrentDirectory,"*", System.IO.SearchOption.AllDirectories);
            foreach(var folder in folders.ToList())
            {
                string item = folder.Replace(GetCurrentDirectory,"");
                string[] files =  Directory.GetFiles(folder);
                List<string> finalFiles = [];
                foreach(var file in files)
                {
                    finalFiles.Add(file.Replace(folder+"\\",""));
                }
                response.Add( new GetWholeDirectorySturctureResponseModel()
                {
                    FolderName = item,
                    FileName = finalFiles
                });
            }
            return response;
        }
    }
}
