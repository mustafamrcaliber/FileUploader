using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using FileUploader.ModelConfigurations;
using FileUploader.EntityFrameworkCore;
using Xunit;

namespace FileUploader.EntityFrameworkCore.Domains.ModelConfigurations
{
    public class ModelConfigurationRepositoryTests : FileUploaderEntityFrameworkCoreTestBase
    {
        private readonly IModelConfigurationRepository _modelConfigurationRepository;

        public ModelConfigurationRepositoryTests()
        {
            _modelConfigurationRepository = GetRequiredService<IModelConfigurationRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _modelConfigurationRepository.GetListAsync(
                    systemPrompt: "98309bd9e9fd497ebc4ae589d2aa315254e41d9720d347ceb9799938a",
                    topK: "b101c11f6df44be088fb82708a999009613f210101cb4c458940d695096a",
                    topP: "5199d8495a4d43578c0a3b644bf7dcb662142692772e456fa872d",
                    repeatPenalty: "f58b7f0cd5dc4437a6f0d0ef5006b8b667d54ab9a",
                    contextLength: "83bc765f11004ddf968f91aae1be1eb295d9140dc74a4fe88de27fe52b92c82b",
                    maxTokens: "b36a967fbefc4b2bbd227d5785d21a18a0199a474ef74b34bd569d6e00ea25889bdf4d08887149b1a0b"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("a5c2e9d8-e49e-4987-bd0d-150896b6736a"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _modelConfigurationRepository.GetCountAsync(
                    systemPrompt: "acdef537c4374641b00eab8",
                    topK: "e688b72f09d44679b35ce9e0801ca667c1b",
                    topP: "bc2c8cf4322a4874960c014533ffe7bdda9954424ba7",
                    repeatPenalty: "568008f8c65c46a28ea66a8bf7bd82e789d5ff019fbb47739be4f1d266ef72",
                    contextLength: "998dc88eff1945fdbb3c24d420d0",
                    maxTokens: "4586b7252ebe411392f1ed352d6d458f2309fdb9e83c4e63bb5330092e97f77eb3e2b3"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}