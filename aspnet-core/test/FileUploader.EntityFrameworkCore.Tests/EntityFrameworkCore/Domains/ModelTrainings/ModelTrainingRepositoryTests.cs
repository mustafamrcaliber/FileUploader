using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using FileUploader.ModelTrainings;
using FileUploader.EntityFrameworkCore;
using Xunit;

namespace FileUploader.EntityFrameworkCore.Domains.ModelTrainings
{
    public class ModelTrainingRepositoryTests : FileUploaderEntityFrameworkCoreTestBase
    {
        private readonly IModelTrainingRepository _modelTrainingRepository;

        public ModelTrainingRepositoryTests()
        {
            _modelTrainingRepository = GetRequiredService<IModelTrainingRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _modelTrainingRepository.GetListAsync(
                    path: "5848b00c8aac4e3",
                    databaseConnectionString: "430ec224540",
                    documentsDirectoryPath: "790770d5f97f4f75a108dad1939d099fde7e812418f84bab9bb97ce7ca16f7bf06f26c0bbad64009864f",
                    trainingLog: "ca9afee295a2473892d2dc34f08f2dbb532"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("c05eb2a2-8715-49b6-8c9d-ec885f121834"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _modelTrainingRepository.GetCountAsync(
                    path: "a329a84638f94479aac206827c0e3c749f2f19ab239542068a2e80ae820d50bab16cfa9926e54696bbde",
                    databaseConnectionString: "6c3fb7cc26844fa688cbbac0975c6660ce3fa4c68bed49348a20c4931d4c515ed65556159d98493aa6a",
                    documentsDirectoryPath: "b3d75815cc554321af6463a0ed73418f47470fd352804f868f5fe96a",
                    trainingLog: "10280dd80a6d41f8846bf8cc77cfb"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}