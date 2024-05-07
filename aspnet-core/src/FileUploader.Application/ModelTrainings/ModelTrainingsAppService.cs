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
using FileUploader.ModelTrainings;

namespace FileUploader.ModelTrainings
{
    [RemoteService(IsEnabled = false)]
    [Authorize(FileUploaderPermissions.ModelTrainings.Default)]
    public abstract class ModelTrainingsAppServiceBase : ApplicationService
    {

        protected IModelTrainingRepository _modelTrainingRepository;
        protected ModelTrainingManager _modelTrainingManager;

        public ModelTrainingsAppServiceBase(IModelTrainingRepository modelTrainingRepository, ModelTrainingManager modelTrainingManager)
        {

            _modelTrainingRepository = modelTrainingRepository;
            _modelTrainingManager = modelTrainingManager;
        }

        public virtual async Task<PagedResultDto<ModelTrainingDto>> GetListAsync(GetModelTrainingsInput input)
        {
            var totalCount = await _modelTrainingRepository.GetCountAsync(input.FilterText, input.TypeMin, input.TypeMax, input.Path, input.DataSourceMin, input.DataSourceMax, input.DatabaseConnectionString, input.DocumentsDirectoryPath, input.ModeMin, input.ModeMax, input.TrainingLog);
            var items = await _modelTrainingRepository.GetListAsync(input.FilterText, input.TypeMin, input.TypeMax, input.Path, input.DataSourceMin, input.DataSourceMax, input.DatabaseConnectionString, input.DocumentsDirectoryPath, input.ModeMin, input.ModeMax, input.TrainingLog, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ModelTrainingDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ModelTraining>, List<ModelTrainingDto>>(items)
            };
        }

        public virtual async Task<ModelTrainingDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ModelTraining, ModelTrainingDto>(await _modelTrainingRepository.GetAsync(id));
        }

        [Authorize(FileUploaderPermissions.ModelTrainings.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _modelTrainingRepository.DeleteAsync(id);
        }

        [Authorize(FileUploaderPermissions.ModelTrainings.Create)]
        public virtual async Task<ModelTrainingDto> CreateAsync(ModelTrainingCreateDto input)
        {

            var modelTraining = await _modelTrainingManager.CreateAsync(
            input.Type, input.DataSource, input.Mode, input.Path, input.DatabaseConnectionString, input.DocumentsDirectoryPath, input.TrainingLog
            );

            return ObjectMapper.Map<ModelTraining, ModelTrainingDto>(modelTraining);
        }

        [Authorize(FileUploaderPermissions.ModelTrainings.Edit)]
        public virtual async Task<ModelTrainingDto> UpdateAsync(Guid id, ModelTrainingUpdateDto input)
        {

            var modelTraining = await _modelTrainingManager.UpdateAsync(
            id,
            input.Type, input.DataSource, input.Mode, input.Path, input.DatabaseConnectionString, input.DocumentsDirectoryPath, input.TrainingLog, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<ModelTraining, ModelTrainingDto>(modelTraining);
        }
    }
}