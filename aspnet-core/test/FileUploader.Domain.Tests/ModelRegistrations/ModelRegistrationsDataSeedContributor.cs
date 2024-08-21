using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using FileUploader.ModelRegistrations;

namespace FileUploader.ModelRegistrations
{
    public class ModelRegistrationsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IModelRegistrationRepository _modelRegistrationRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ModelRegistrationsDataSeedContributor(IModelRegistrationRepository modelRegistrationRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _modelRegistrationRepository = modelRegistrationRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _modelRegistrationRepository.InsertAsync(new ModelRegistration
            (
                id: Guid.Parse("3943f29f-2044-4a39-954d-981b8ee696f1"),
                model: 323965737,
                apiPath: "cfbd5af650c741ec991e28884f4f15a89084f8dbab1b445daac96f",
                localPath: "15f749ea92a24ba",
                schedule: 1886890643,
                interval: 272323887
            ));

            await _modelRegistrationRepository.InsertAsync(new ModelRegistration
            (
                id: Guid.Parse("ee859a57-1dc8-4cc9-aa98-166903980a4c"),
                model: 301572411,
                apiPath: "c7774b84a66f41cd95",
                localPath: "9aa4835d42bb4",
                schedule: 73318385,
                interval: 731816314
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}