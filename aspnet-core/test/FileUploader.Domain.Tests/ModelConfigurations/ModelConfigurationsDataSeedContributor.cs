using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using FileUploader.ModelConfigurations;

namespace FileUploader.ModelConfigurations
{
    public class ModelConfigurationsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IModelConfigurationRepository _modelConfigurationRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ModelConfigurationsDataSeedContributor(IModelConfigurationRepository modelConfigurationRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _modelConfigurationRepository = modelConfigurationRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _modelConfigurationRepository.InsertAsync(new ModelConfiguration
            (
                id: Guid.Parse("a5c2e9d8-e49e-4987-bd0d-150896b6736a"),
                systemPrompt: "98309bd9e9fd497ebc4ae589d2aa315254e41d9720d347ceb9799938a",
                temperature: 1995752684,
                topK: "b101c11f6df44be088fb82708a999009613f210101cb4c458940d695096a",
                topP: "5199d8495a4d43578c0a3b644bf7dcb662142692772e456fa872d",
                repeatPenalty: "f58b7f0cd5dc4437a6f0d0ef5006b8b667d54ab9a",
                contextLength: "83bc765f11004ddf968f91aae1be1eb295d9140dc74a4fe88de27fe52b92c82b",
                maxTokens: "b36a967fbefc4b2bbd227d5785d21a18a0199a474ef74b34bd569d6e00ea25889bdf4d08887149b1a0b"
            ));

            await _modelConfigurationRepository.InsertAsync(new ModelConfiguration
            (
                id: Guid.Parse("4da8e513-af3f-4ce1-ac7b-4f558667155b"),
                systemPrompt: "acdef537c4374641b00eab8",
                temperature: 626142110,
                topK: "e688b72f09d44679b35ce9e0801ca667c1b",
                topP: "bc2c8cf4322a4874960c014533ffe7bdda9954424ba7",
                repeatPenalty: "568008f8c65c46a28ea66a8bf7bd82e789d5ff019fbb47739be4f1d266ef72",
                contextLength: "998dc88eff1945fdbb3c24d420d0",
                maxTokens: "4586b7252ebe411392f1ed352d6d458f2309fdb9e83c4e63bb5330092e97f77eb3e2b3"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}