using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace FileUploader.UploadFiles
{
    public abstract class UploadFileManagerBase : DomainService
    {
        protected IUploadFileRepository _uploadFileRepository;

        public UploadFileManagerBase(IUploadFileRepository uploadFileRepository)
        {
            _uploadFileRepository = uploadFileRepository;
        }

        public virtual async Task<UploadFile> CreateAsync(
        string? fileName = null, string? filePath = null, string? fileType = null, string? fileSize = null)
        {

            var uploadFile = new UploadFile(
             GuidGenerator.Create(),
             fileName, filePath, fileType, fileSize
             );

            return await _uploadFileRepository.InsertAsync(uploadFile);
        }

        public virtual async Task<UploadFile> UpdateAsync(
            Guid id,
            string? fileName = null, string? filePath = null, string? fileType = null, string? fileSize = null, [CanBeNull] string? concurrencyStamp = null
        )
        {

            var uploadFile = await _uploadFileRepository.GetAsync(id);

            uploadFile.FileName = fileName;
            uploadFile.FilePath = filePath;
            uploadFile.FileType = fileType;
            uploadFile.FileSize = fileSize;

            uploadFile.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _uploadFileRepository.UpdateAsync(uploadFile);
        }

    }
}