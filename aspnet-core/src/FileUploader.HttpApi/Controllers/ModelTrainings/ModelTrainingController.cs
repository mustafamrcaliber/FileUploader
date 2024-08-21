using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using FileUploader.ModelTrainings;

namespace FileUploader.Controllers.ModelTrainings
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ModelTraining")]
    [Route("api/app/model-trainings")]

    public abstract class ModelTrainingControllerBase : AbpController
    {
        protected IModelTrainingsAppService _modelTrainingsAppService;

        public ModelTrainingControllerBase(IModelTrainingsAppService modelTrainingsAppService)
        {
            _modelTrainingsAppService = modelTrainingsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ModelTrainingDto>> GetListAsync(GetModelTrainingsInput input)
        {
            return _modelTrainingsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ModelTrainingDto> GetAsync(Guid id)
        {
            return _modelTrainingsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ModelTrainingDto> CreateAsync(ModelTrainingCreateDto input)
        {
            return _modelTrainingsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ModelTrainingDto> UpdateAsync(Guid id, ModelTrainingUpdateDto input)
        {
            return _modelTrainingsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _modelTrainingsAppService.DeleteAsync(id);
        }
    }
}