using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using FileUploader.UploadFiles;
using FileUploader.EntityFrameworkCore;
using Xunit;

namespace FileUploader.EntityFrameworkCore.Domains.UploadFiles
{
    public class UploadFileRepositoryTests : FileUploaderEntityFrameworkCoreTestBase
    {
        private readonly IUploadFileRepository _uploadFileRepository;

        public UploadFileRepositoryTests()
        {
            _uploadFileRepository = GetRequiredService<IUploadFileRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _uploadFileRepository.GetListAsync(
                    fileName: "f1757269361044a680f2f9c8cd51a1c521c01404cd9748908f0f6692b8d6fa58befe5771d80b40469b8aacd",
                    filePath: "b927a27f9c6a472b9190924cea8d82fee0c9a7f268964e948fad5a8905a",
                    fileType: "25abfffb27f64bdb9da8c33d7578a8",
                    fileSize: "7f041c46b85b4"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("01cfa167-4848-486d-82ce-8123bf945c50"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _uploadFileRepository.GetCountAsync(
                    fileName: "fb559f1684a0446e8cb216bb4f11b45823b0e0f0376c4ad08304c9e3c",
                    filePath: "55b0045793674f23adeeda079cd1a1b5e006ac335db9477bbb",
                    fileType: "f7ca261a01e94af8aacd6f85f392f57fab78d7e69",
                    fileSize: "e33317ada97f492e9f7380bd65ec8826f3501e8a5a93467baf0cd82d8cfd53e05a"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}