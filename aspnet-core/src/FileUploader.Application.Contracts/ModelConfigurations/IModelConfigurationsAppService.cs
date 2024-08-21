using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FileUploader.ModelConfigurations
{
    public partial interface IModelConfigurationsAppService : IApplicationService
    {

        Task<PagedResultDto<ModelConfigurationDto>> GetListAsync(GetModelConfigurationsInput input);

        Task<ModelConfigurationDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ModelConfigurationDto> CreateAsync(ModelConfigurationCreateDto input);

        Task<ModelConfigurationDto> UpdateAsync(Guid id, ModelConfigurationUpdateDto input);
    }
}