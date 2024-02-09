using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace FileUploader.UploadFiles
{
    public abstract class UploadFilesAppServiceTests<TStartupModule> : FileUploaderApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IUploadFilesAppService _uploadFilesAppService;
        private readonly IRepository<UploadFile, Guid> _uploadFileRepository;

        public UploadFilesAppServiceTests()
        {
            _uploadFilesAppService = GetRequiredService<IUploadFilesAppService>();
            _uploadFileRepository = GetRequiredService<IRepository<UploadFile, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _uploadFilesAppService.GetListAsync(new GetUploadFilesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("01cfa167-4848-486d-82ce-8123bf945c50")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("6898828d-b0bf-4ac2-8cb1-6a15ab705f6e")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _uploadFilesAppService.GetAsync(Guid.Parse("01cfa167-4848-486d-82ce-8123bf945c50"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("01cfa167-4848-486d-82ce-8123bf945c50"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UploadFileCreateDto
            {
                FileName = "0739f512715b4efab42f41b1da3b94f26275f6121be342398ccbaf65ade474",
                FilePath = "94a264abbd1d490691e59ad04aa02a754861aade858741d58635491481ba1e0e30bfb7943c",
                FileType = "0fed2ebed8c44ff1b65e1e",
                FileSize = "cdec0c063b5943"
            };

            // Act
            var serviceResult = await _uploadFilesAppService.CreateAsync(input);

            // Assert
            var result = await _uploadFileRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.FileName.ShouldBe("0739f512715b4efab42f41b1da3b94f26275f6121be342398ccbaf65ade474");
            result.FilePath.ShouldBe("94a264abbd1d490691e59ad04aa02a754861aade858741d58635491481ba1e0e30bfb7943c");
            result.FileType.ShouldBe("0fed2ebed8c44ff1b65e1e");
            result.FileSize.ShouldBe("cdec0c063b5943");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UploadFileUpdateDto()
            {
                FileName = "15f4b972605e4715b08a3b6838335c71834a118e667f4cf79a1240d3c1ed3eb39814c21789774539b39efd2a07",
                FilePath = "232a1cc2148b47319b2612262349c430cdd",
                FileType = "43e3051eea3e4ed194196fa8674ef91235dee86496e54cb1a4459",
                FileSize = "9af779c4b09c42658136dbcbd06d3042196438819e86460eac733c3d08adf6ae07fe"
            };

            // Act
            var serviceResult = await _uploadFilesAppService.UpdateAsync(Guid.Parse("01cfa167-4848-486d-82ce-8123bf945c50"), input);

            // Assert
            var result = await _uploadFileRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.FileName.ShouldBe("15f4b972605e4715b08a3b6838335c71834a118e667f4cf79a1240d3c1ed3eb39814c21789774539b39efd2a07");
            result.FilePath.ShouldBe("232a1cc2148b47319b2612262349c430cdd");
            result.FileType.ShouldBe("43e3051eea3e4ed194196fa8674ef91235dee86496e54cb1a4459");
            result.FileSize.ShouldBe("9af779c4b09c42658136dbcbd06d3042196438819e86460eac733c3d08adf6ae07fe");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _uploadFilesAppService.DeleteAsync(Guid.Parse("01cfa167-4848-486d-82ce-8123bf945c50"));

            // Assert
            var result = await _uploadFileRepository.FindAsync(c => c.Id == Guid.Parse("01cfa167-4848-486d-82ce-8123bf945c50"));

            result.ShouldBeNull();
        }
    }
}