using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace FileUploader.ModelTrainings
{
    public abstract class ModelTrainingsAppServiceTests<TStartupModule> : FileUploaderApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IModelTrainingsAppService _modelTrainingsAppService;
        private readonly IRepository<ModelTraining, Guid> _modelTrainingRepository;

        public ModelTrainingsAppServiceTests()
        {
            _modelTrainingsAppService = GetRequiredService<IModelTrainingsAppService>();
            _modelTrainingRepository = GetRequiredService<IRepository<ModelTraining, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _modelTrainingsAppService.GetListAsync(new GetModelTrainingsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("c05eb2a2-8715-49b6-8c9d-ec885f121834")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("86b6111a-a2f8-475b-a104-308da386c7fd")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _modelTrainingsAppService.GetAsync(Guid.Parse("c05eb2a2-8715-49b6-8c9d-ec885f121834"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("c05eb2a2-8715-49b6-8c9d-ec885f121834"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ModelTrainingCreateDto
            {
                Type = 777789233,
                Path = "facd5cac5d",
                DataSource = 2010722501,
                DatabaseConnectionString = "545e86bd4d88478d9bd943d8bd879293e7eadeac6bfd4a5388337168a",
                DocumentsDirectoryPath = "5fc12cfe67ab4dd38249804a83909356b66a9d",
                Mode = 298121081,
                TrainingLog = "ad73fa70af70488da039bfedf4691cdd601aba99"
            };

            // Act
            var serviceResult = await _modelTrainingsAppService.CreateAsync(input);

            // Assert
            var result = await _modelTrainingRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Type.ShouldBe(777789233);
            result.Path.ShouldBe("facd5cac5d");
            result.DataSource.ShouldBe(2010722501);
            result.DatabaseConnectionString.ShouldBe("545e86bd4d88478d9bd943d8bd879293e7eadeac6bfd4a5388337168a");
            result.DocumentsDirectoryPath.ShouldBe("5fc12cfe67ab4dd38249804a83909356b66a9d");
            result.Mode.ShouldBe(298121081);
            result.TrainingLog.ShouldBe("ad73fa70af70488da039bfedf4691cdd601aba99");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ModelTrainingUpdateDto()
            {
                Type = 816979572,
                Path = "8c7789d7f87b4b6ca4fd0d633a9539",
                DataSource = 1942495515,
                DatabaseConnectionString = "673be7bbf02943cc9830f11aff48b8c7b264d37bc7ba490d85a70fe044778e6abaa9c1ff",
                DocumentsDirectoryPath = "21d7335332df438dae56d272e4f0af10a",
                Mode = 1825772543,
                TrainingLog = "b78d2b7ea6954e158ea90a639f37d56f0bff2b4ca1e74796a48f677330647a7b1a2f2a66b65d4"
            };

            // Act
            var serviceResult = await _modelTrainingsAppService.UpdateAsync(Guid.Parse("c05eb2a2-8715-49b6-8c9d-ec885f121834"), input);

            // Assert
            var result = await _modelTrainingRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Type.ShouldBe(816979572);
            result.Path.ShouldBe("8c7789d7f87b4b6ca4fd0d633a9539");
            result.DataSource.ShouldBe(1942495515);
            result.DatabaseConnectionString.ShouldBe("673be7bbf02943cc9830f11aff48b8c7b264d37bc7ba490d85a70fe044778e6abaa9c1ff");
            result.DocumentsDirectoryPath.ShouldBe("21d7335332df438dae56d272e4f0af10a");
            result.Mode.ShouldBe(1825772543);
            result.TrainingLog.ShouldBe("b78d2b7ea6954e158ea90a639f37d56f0bff2b4ca1e74796a48f677330647a7b1a2f2a66b65d4");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _modelTrainingsAppService.DeleteAsync(Guid.Parse("c05eb2a2-8715-49b6-8c9d-ec885f121834"));

            // Assert
            var result = await _modelTrainingRepository.FindAsync(c => c.Id == Guid.Parse("c05eb2a2-8715-49b6-8c9d-ec885f121834"));

            result.ShouldBeNull();
        }
    }
}