using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace FileUploader.ModelConfigurations
{
    public abstract class ModelConfigurationsAppServiceTests<TStartupModule> : FileUploaderApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IModelConfigurationsAppService _modelConfigurationsAppService;
        private readonly IRepository<ModelConfiguration, Guid> _modelConfigurationRepository;

        public ModelConfigurationsAppServiceTests()
        {
            _modelConfigurationsAppService = GetRequiredService<IModelConfigurationsAppService>();
            _modelConfigurationRepository = GetRequiredService<IRepository<ModelConfiguration, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _modelConfigurationsAppService.GetListAsync(new GetModelConfigurationsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("a5c2e9d8-e49e-4987-bd0d-150896b6736a")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("4da8e513-af3f-4ce1-ac7b-4f558667155b")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _modelConfigurationsAppService.GetAsync(Guid.Parse("a5c2e9d8-e49e-4987-bd0d-150896b6736a"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("a5c2e9d8-e49e-4987-bd0d-150896b6736a"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ModelConfigurationCreateDto
            {
                SystemPrompt = "42a1a3d4b56c4da1b0623c7b85838d55e1ee02a27ad74c",
                Temperature = 1095030035,
                TopK = "a8127bfb7b2242db8258af9dfa49de2b649bb0592c7e4ffa9c4a0e575338",
                TopP = "2719563fabd94f3eb88d05193b6e8d5b6fc5240bd16b408f833756ffc30baf7e8c8f566d3f4f4dba8641e02352268b7",
                RepeatPenalty = "baec3907f4c04de8890eec1d275adcb954701b1f37e24713bb",
                ContextLength = "d8268c15b366407bba43c40f3b317c817d8eaa93e3ca4853b031163f76ae1e9cd0f3b9740a9646ec982c05b03c14d6",
                MaxTokens = "d57fee52f68d4218a44e0672d938a6cc6840109616244a84b4481a7cc42bf2a9d834efa0f7"
            };

            // Act
            var serviceResult = await _modelConfigurationsAppService.CreateAsync(input);

            // Assert
            var result = await _modelConfigurationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.SystemPrompt.ShouldBe("42a1a3d4b56c4da1b0623c7b85838d55e1ee02a27ad74c");
            result.Temperature.ShouldBe(1095030035);
            result.TopK.ShouldBe("a8127bfb7b2242db8258af9dfa49de2b649bb0592c7e4ffa9c4a0e575338");
            result.TopP.ShouldBe("2719563fabd94f3eb88d05193b6e8d5b6fc5240bd16b408f833756ffc30baf7e8c8f566d3f4f4dba8641e02352268b7");
            result.RepeatPenalty.ShouldBe("baec3907f4c04de8890eec1d275adcb954701b1f37e24713bb");
            result.ContextLength.ShouldBe("d8268c15b366407bba43c40f3b317c817d8eaa93e3ca4853b031163f76ae1e9cd0f3b9740a9646ec982c05b03c14d6");
            result.MaxTokens.ShouldBe("d57fee52f68d4218a44e0672d938a6cc6840109616244a84b4481a7cc42bf2a9d834efa0f7");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ModelConfigurationUpdateDto()
            {
                SystemPrompt = "003562e86144448c9eb489a095c37f6f16c7",
                Temperature = 80094626,
                TopK = "9d7e5d8a328d4073921cea678187d81dedd8160575344984b440b2917621ed1000f657bede6a498caea1276b00ead2c7",
                TopP = "32aaf8fa0053403eaf483956b60dee3e73f04ed7270d4d7abe19bc7aedd547dbda1781",
                RepeatPenalty = "a1dcf8ee4b86449ba98487d679d97d7",
                ContextLength = "3015c1b63f5042a8b1881f4741ec59b",
                MaxTokens = "d08ca8c568414a1aa8b35422dcedfdc00182423ae4ef4971898b3c0a3811"
            };

            // Act
            var serviceResult = await _modelConfigurationsAppService.UpdateAsync(Guid.Parse("a5c2e9d8-e49e-4987-bd0d-150896b6736a"), input);

            // Assert
            var result = await _modelConfigurationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.SystemPrompt.ShouldBe("003562e86144448c9eb489a095c37f6f16c7");
            result.Temperature.ShouldBe(80094626);
            result.TopK.ShouldBe("9d7e5d8a328d4073921cea678187d81dedd8160575344984b440b2917621ed1000f657bede6a498caea1276b00ead2c7");
            result.TopP.ShouldBe("32aaf8fa0053403eaf483956b60dee3e73f04ed7270d4d7abe19bc7aedd547dbda1781");
            result.RepeatPenalty.ShouldBe("a1dcf8ee4b86449ba98487d679d97d7");
            result.ContextLength.ShouldBe("3015c1b63f5042a8b1881f4741ec59b");
            result.MaxTokens.ShouldBe("d08ca8c568414a1aa8b35422dcedfdc00182423ae4ef4971898b3c0a3811");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _modelConfigurationsAppService.DeleteAsync(Guid.Parse("a5c2e9d8-e49e-4987-bd0d-150896b6736a"));

            // Assert
            var result = await _modelConfigurationRepository.FindAsync(c => c.Id == Guid.Parse("a5c2e9d8-e49e-4987-bd0d-150896b6736a"));

            result.ShouldBeNull();
        }
    }
}