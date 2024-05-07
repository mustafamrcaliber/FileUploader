using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using FileUploader.Permissions;
using FileUploader.ModelConfigurations;

namespace FileUploader.ModelConfigurations
{
    [RemoteService(IsEnabled = false)]
    [Authorize(FileUploaderPermissions.ModelConfigurations.Default)]
    public abstract class ModelConfigurationsAppServiceBase : ApplicationService
    {

        protected IModelConfigurationRepository _modelConfigurationRepository;
        protected ModelConfigurationManager _modelConfigurationManager;

        public ModelConfigurationsAppServiceBase(IModelConfigurationRepository modelConfigurationRepository, ModelConfigurationManager modelConfigurationManager)
        {

            _modelConfigurationRepository = modelConfigurationRepository;
            _modelConfigurationManager = modelConfigurationManager;
        }

        public virtual async Task<PagedResultDto<ModelConfigurationDto>> GetListAsync(GetModelConfigurationsInput input)
        {
            var totalCount = await _modelConfigurationRepository.GetCountAsync(input.FilterText, input.SystemPrompt, input.TemperatureMin, input.TemperatureMax, input.TopK, input.TopP, input.RepeatPenalty, input.ContextLength, input.MaxTokens);
            var items = await _modelConfigurationRepository.GetListAsync(input.FilterText, input.SystemPrompt, input.TemperatureMin, input.TemperatureMax, input.TopK, input.TopP, input.RepeatPenalty, input.ContextLength, input.MaxTokens, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ModelConfigurationDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ModelConfiguration>, List<ModelConfigurationDto>>(items)
            };
        }

        public virtual async Task<ModelConfigurationDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ModelConfiguration, ModelConfigurationDto>(await _modelConfigurationRepository.GetAsync(id));
        }

        [Authorize(FileUploaderPermissions.ModelConfigurations.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _modelConfigurationRepository.DeleteAsync(id);
        }

        [Authorize(FileUploaderPermissions.ModelConfigurations.Create)]
        public virtual async Task<ModelConfigurationDto> CreateAsync(ModelConfigurationCreateDto input)
        {

            var modelConfiguration = await _modelConfigurationManager.CreateAsync(
            input.Temperature, input.SystemPrompt, input.TopK, input.TopP, input.RepeatPenalty, input.ContextLength, input.MaxTokens
            );

            return ObjectMapper.Map<ModelConfiguration, ModelConfigurationDto>(modelConfiguration);
        }

        [Authorize(FileUploaderPermissions.ModelConfigurations.Edit)]
        public virtual async Task<ModelConfigurationDto> UpdateAsync(Guid id, ModelConfigurationUpdateDto input)
        {

            var modelConfiguration = await _modelConfigurationManager.UpdateAsync(
            id,
            input.Temperature, input.SystemPrompt, input.TopK, input.TopP, input.RepeatPenalty, input.ContextLength, input.MaxTokens, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<ModelConfiguration, ModelConfigurationDto>(modelConfiguration);
        }
    }
}