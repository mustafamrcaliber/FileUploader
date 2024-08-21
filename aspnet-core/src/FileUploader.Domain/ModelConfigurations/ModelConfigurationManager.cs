using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace FileUploader.ModelConfigurations
{
    public abstract class ModelConfigurationManagerBase : DomainService
    {
        protected IModelConfigurationRepository _modelConfigurationRepository;

        public ModelConfigurationManagerBase(IModelConfigurationRepository modelConfigurationRepository)
        {
            _modelConfigurationRepository = modelConfigurationRepository;
        }

        public virtual async Task<ModelConfiguration> CreateAsync(
        double temperature, string? systemPrompt = null, string? topK = null, string? topP = null, string? repeatPenalty = null, string? contextLength = null, string? maxTokens = null)
        {

            var modelConfiguration = new ModelConfiguration(
             GuidGenerator.Create(),
             temperature, systemPrompt, topK, topP, repeatPenalty, contextLength, maxTokens
             );

            return await _modelConfigurationRepository.InsertAsync(modelConfiguration);
        }

        public virtual async Task<ModelConfiguration> UpdateAsync(
            Guid id,
            double temperature, string? systemPrompt = null, string? topK = null, string? topP = null, string? repeatPenalty = null, string? contextLength = null, string? maxTokens = null, [CanBeNull] string? concurrencyStamp = null
        )
        {

            var modelConfiguration = await _modelConfigurationRepository.GetAsync(id);

            modelConfiguration.Temperature = temperature;
            modelConfiguration.SystemPrompt = systemPrompt;
            modelConfiguration.TopK = topK;
            modelConfiguration.TopP = topP;
            modelConfiguration.RepeatPenalty = repeatPenalty;
            modelConfiguration.ContextLength = contextLength;
            modelConfiguration.MaxTokens = maxTokens;

            modelConfiguration.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _modelConfigurationRepository.UpdateAsync(modelConfiguration);
        }

    }
}