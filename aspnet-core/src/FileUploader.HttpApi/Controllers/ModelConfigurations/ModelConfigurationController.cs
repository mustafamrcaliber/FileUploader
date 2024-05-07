using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using FileUploader.ModelConfigurations;

namespace FileUploader.Controllers.ModelConfigurations
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ModelConfiguration")]
    [Route("api/app/model-configurations")]

    public abstract class ModelConfigurationControllerBase : AbpController
    {
        protected IModelConfigurationsAppService _modelConfigurationsAppService;

        public ModelConfigurationControllerBase(IModelConfigurationsAppService modelConfigurationsAppService)
        {
            _modelConfigurationsAppService = modelConfigurationsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ModelConfigurationDto>> GetListAsync(GetModelConfigurationsInput input)
        {
            return _modelConfigurationsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ModelConfigurationDto> GetAsync(Guid id)
        {
            return _modelConfigurationsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ModelConfigurationDto> CreateAsync(ModelConfigurationCreateDto input)
        {
            return _modelConfigurationsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ModelConfigurationDto> UpdateAsync(Guid id, ModelConfigurationUpdateDto input)
        {
            return _modelConfigurationsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _modelConfigurationsAppService.DeleteAsync(id);
        }
    }
}