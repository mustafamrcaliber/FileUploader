using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using FileUploader.UploadFiles;

namespace FileUploader.UploadFiles
{
    public class UploadFilesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUploadFileRepository _uploadFileRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UploadFilesDataSeedContributor(IUploadFileRepository uploadFileRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _uploadFileRepository = uploadFileRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _uploadFileRepository.InsertAsync(new UploadFile
            (
                id: Guid.Parse("01cfa167-4848-486d-82ce-8123bf945c50"),
                fileName: "f1757269361044a680f2f9c8cd51a1c521c01404cd9748908f0f6692b8d6fa58befe5771d80b40469b8aacd",
                filePath: "b927a27f9c6a472b9190924cea8d82fee0c9a7f268964e948fad5a8905a",
                fileType: "25abfffb27f64bdb9da8c33d7578a8",
                fileSize: "7f041c46b85b4"
            ));

            await _uploadFileRepository.InsertAsync(new UploadFile
            (
                id: Guid.Parse("6898828d-b0bf-4ac2-8cb1-6a15ab705f6e"),
                fileName: "fb559f1684a0446e8cb216bb4f11b45823b0e0f0376c4ad08304c9e3c",
                filePath: "55b0045793674f23adeeda079cd1a1b5e006ac335db9477bbb",
                fileType: "f7ca261a01e94af8aacd6f85f392f57fab78d7e69",
                fileSize: "e33317ada97f492e9f7380bd65ec8826f3501e8a5a93467baf0cd82d8cfd53e05a"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}