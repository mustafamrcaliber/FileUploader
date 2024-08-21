using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FileUploader.ModelRegistrations
{
    public partial interface IModelRegistrationsAppService : IApplicationService
    {

        Task<PagedResultDto<ModelRegistrationDto>> GetListAsync(GetModelRegistrationsInput input);

        Task<ModelRegistrationDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ModelRegistrationDto> CreateAsync(ModelRegistrationCreateDto input);

        Task<ModelRegistrationDto> UpdateAsync(Guid id, ModelRegistrationUpdateDto input);
    }
}