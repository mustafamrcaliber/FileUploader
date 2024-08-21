using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using FileUploader.ModelRegistrations;
using FileUploader.EntityFrameworkCore;
using Xunit;

namespace FileUploader.EntityFrameworkCore.Domains.ModelRegistrations
{
    public class ModelRegistrationRepositoryTests : FileUploaderEntityFrameworkCoreTestBase
    {
        private readonly IModelRegistrationRepository _modelRegistrationRepository;

        public ModelRegistrationRepositoryTests()
        {
            _modelRegistrationRepository = GetRequiredService<IModelRegistrationRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _modelRegistrationRepository.GetListAsync(
                    apiPath: "cfbd5af650c741ec991e28884f4f15a89084f8dbab1b445daac96f",
                    localPath: "15f749ea92a24ba"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("3943f29f-2044-4a39-954d-981b8ee696f1"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _modelRegistrationRepository.GetCountAsync(
                    apiPath: "c7774b84a66f41cd95",
                    localPath: "9aa4835d42bb4"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}