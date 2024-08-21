using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using FileUploader.ModelRegistrations;

namespace FileUploader.Controllers.ModelRegistrations
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ModelRegistration")]
    [Route("api/app/model-registrations")]

    public abstract class ModelRegistrationControllerBase : AbpController
    {
        protected IModelRegistrationsAppService _modelRegistrationsAppService;

        public ModelRegistrationControllerBase(IModelRegistrationsAppService modelRegistrationsAppService)
        {
            _modelRegistrationsAppService = modelRegistrationsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ModelRegistrationDto>> GetListAsync(GetModelRegistrationsInput input)
        {
            return _modelRegistrationsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ModelRegistrationDto> GetAsync(Guid id)
        {
            return _modelRegistrationsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ModelRegistrationDto> CreateAsync(ModelRegistrationCreateDto input)
        {
            return _modelRegistrationsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ModelRegistrationDto> UpdateAsync(Guid id, ModelRegistrationUpdateDto input)
        {
            return _modelRegistrationsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _modelRegistrationsAppService.DeleteAsync(id);
        }
    }
}