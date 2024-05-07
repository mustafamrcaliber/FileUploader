using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FileUploader.ModelTrainings
{
    public partial interface IModelTrainingsAppService : IApplicationService
    {

        Task<PagedResultDto<ModelTrainingDto>> GetListAsync(GetModelTrainingsInput input);

        Task<ModelTrainingDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ModelTrainingDto> CreateAsync(ModelTrainingCreateDto input);

        Task<ModelTrainingDto> UpdateAsync(Guid id, ModelTrainingUpdateDto input);
    }
}