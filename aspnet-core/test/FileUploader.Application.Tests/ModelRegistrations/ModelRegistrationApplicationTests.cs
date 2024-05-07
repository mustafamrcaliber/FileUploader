using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace FileUploader.ModelRegistrations
{
    public abstract class ModelRegistrationsAppServiceTests<TStartupModule> : FileUploaderApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IModelRegistrationsAppService _modelRegistrationsAppService;
        private readonly IRepository<ModelRegistration, Guid> _modelRegistrationRepository;

        public ModelRegistrationsAppServiceTests()
        {
            _modelRegistrationsAppService = GetRequiredService<IModelRegistrationsAppService>();
            _modelRegistrationRepository = GetRequiredService<IRepository<ModelRegistration, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _modelRegistrationsAppService.GetListAsync(new GetModelRegistrationsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("3943f29f-2044-4a39-954d-981b8ee696f1")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("ee859a57-1dc8-4cc9-aa98-166903980a4c")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _modelRegistrationsAppService.GetAsync(Guid.Parse("3943f29f-2044-4a39-954d-981b8ee696f1"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("3943f29f-2044-4a39-954d-981b8ee696f1"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ModelRegistrationCreateDto
            {
                Model = 238056151,
                ApiPath = "a84806f6e73949b3a38246a837ac5727",
                LocalPath = "ea0a863f5d66428f911def37fe2b7b5",
                Schedule = 1097080087,
                Interval = 1579984375
            };

            // Act
            var serviceResult = await _modelRegistrationsAppService.CreateAsync(input);

            // Assert
            var result = await _modelRegistrationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Model.ShouldBe(238056151);
            result.ApiPath.ShouldBe("a84806f6e73949b3a38246a837ac5727");
            result.LocalPath.ShouldBe("ea0a863f5d66428f911def37fe2b7b5");
            result.Schedule.ShouldBe(1097080087);
            result.Interval.ShouldBe(1579984375);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ModelRegistrationUpdateDto()
            {
                Model = 852689450,
                ApiPath = "aea1f302cf554f718f0b261d65d76bb37c47a05b8b8e4273a93b01fd1e702be472e67f922c9e4ad9b2798fbe251667",
                LocalPath = "02a299ad065348c6ae16b7f96ac069c140e169a3",
                Schedule = 619504597,
                Interval = 1399199120
            };

            // Act
            var serviceResult = await _modelRegistrationsAppService.UpdateAsync(Guid.Parse("3943f29f-2044-4a39-954d-981b8ee696f1"), input);

            // Assert
            var result = await _modelRegistrationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Model.ShouldBe(852689450);
            result.ApiPath.ShouldBe("aea1f302cf554f718f0b261d65d76bb37c47a05b8b8e4273a93b01fd1e702be472e67f922c9e4ad9b2798fbe251667");
            result.LocalPath.ShouldBe("02a299ad065348c6ae16b7f96ac069c140e169a3");
            result.Schedule.ShouldBe(619504597);
            result.Interval.ShouldBe(1399199120);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _modelRegistrationsAppService.DeleteAsync(Guid.Parse("3943f29f-2044-4a39-954d-981b8ee696f1"));

            // Assert
            var result = await _modelRegistrationRepository.FindAsync(c => c.Id == Guid.Parse("3943f29f-2044-4a39-954d-981b8ee696f1"));

            result.ShouldBeNull();
        }
    }
}