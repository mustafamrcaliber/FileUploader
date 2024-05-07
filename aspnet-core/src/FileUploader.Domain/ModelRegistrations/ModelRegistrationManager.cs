using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace FileUploader.ModelRegistrations
{
    public abstract class ModelRegistrationManagerBase : DomainService
    {
        protected IModelRegistrationRepository _modelRegistrationRepository;

        public ModelRegistrationManagerBase(IModelRegistrationRepository modelRegistrationRepository)
        {
            _modelRegistrationRepository = modelRegistrationRepository;
        }

        public virtual async Task<ModelRegistration> CreateAsync(
        int model, int schedule, double interval, string? apiPath = null, string? localPath = null)
        {

            var modelRegistration = new ModelRegistration(
             GuidGenerator.Create(),
             model, schedule, interval, apiPath, localPath
             );

            return await _modelRegistrationRepository.InsertAsync(modelRegistration);
        }

        public virtual async Task<ModelRegistration> UpdateAsync(
            Guid id,
            int model, int schedule, double interval, string? apiPath = null, string? localPath = null, [CanBeNull] string? concurrencyStamp = null
        )
        {

            var modelRegistration = await _modelRegistrationRepository.GetAsync(id);

            modelRegistration.Model = model;
            modelRegistration.Schedule = schedule;
            modelRegistration.Interval = interval;
            modelRegistration.ApiPath = apiPath;
            modelRegistration.LocalPath = localPath;

            modelRegistration.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _modelRegistrationRepository.UpdateAsync(modelRegistration);
        }

    }
}