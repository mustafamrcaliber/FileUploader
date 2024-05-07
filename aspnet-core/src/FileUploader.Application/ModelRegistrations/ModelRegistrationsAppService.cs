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
using FileUploader.ModelRegistrations;

namespace FileUploader.ModelRegistrations
{
    [RemoteService(IsEnabled = false)]
    [Authorize(FileUploaderPermissions.ModelRegistrations.Default)]
    public abstract class ModelRegistrationsAppServiceBase : ApplicationService
    {

        protected IModelRegistrationRepository _modelRegistrationRepository;
        protected ModelRegistrationManager _modelRegistrationManager;

        public ModelRegistrationsAppServiceBase(IModelRegistrationRepository modelRegistrationRepository, ModelRegistrationManager modelRegistrationManager)
        {

            _modelRegistrationRepository = modelRegistrationRepository;
            _modelRegistrationManager = modelRegistrationManager;
        }

        public virtual async Task<PagedResultDto<ModelRegistrationDto>> GetListAsync(GetModelRegistrationsInput input)
        {
            var totalCount = await _modelRegistrationRepository.GetCountAsync(input.FilterText, input.ModelMin, input.ModelMax, input.ApiPath, input.LocalPath, input.ScheduleMin, input.ScheduleMax, input.IntervalMin, input.IntervalMax);
            var items = await _modelRegistrationRepository.GetListAsync(input.FilterText, input.ModelMin, input.ModelMax, input.ApiPath, input.LocalPath, input.ScheduleMin, input.ScheduleMax, input.IntervalMin, input.IntervalMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ModelRegistrationDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ModelRegistration>, List<ModelRegistrationDto>>(items)
            };
        }

        public virtual async Task<ModelRegistrationDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ModelRegistration, ModelRegistrationDto>(await _modelRegistrationRepository.GetAsync(id));
        }

        [Authorize(FileUploaderPermissions.ModelRegistrations.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _modelRegistrationRepository.DeleteAsync(id);
        }

        [Authorize(FileUploaderPermissions.ModelRegistrations.Create)]
        public virtual async Task<ModelRegistrationDto> CreateAsync(ModelRegistrationCreateDto input)
        {

            var modelRegistration = await _modelRegistrationManager.CreateAsync(
            input.Model, input.Schedule, input.Interval, input.ApiPath, input.LocalPath
            );

            return ObjectMapper.Map<ModelRegistration, ModelRegistrationDto>(modelRegistration);
        }

        [Authorize(FileUploaderPermissions.ModelRegistrations.Edit)]
        public virtual async Task<ModelRegistrationDto> UpdateAsync(Guid id, ModelRegistrationUpdateDto input)
        {

            var modelRegistration = await _modelRegistrationManager.UpdateAsync(
            id,
            input.Model, input.Schedule, input.Interval, input.ApiPath, input.LocalPath, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<ModelRegistration, ModelRegistrationDto>(modelRegistration);
        }
    }
}