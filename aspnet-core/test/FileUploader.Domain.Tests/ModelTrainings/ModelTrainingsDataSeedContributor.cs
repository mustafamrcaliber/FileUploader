using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using FileUploader.ModelTrainings;

namespace FileUploader.ModelTrainings
{
    public class ModelTrainingsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IModelTrainingRepository _modelTrainingRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ModelTrainingsDataSeedContributor(IModelTrainingRepository modelTrainingRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _modelTrainingRepository = modelTrainingRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _modelTrainingRepository.InsertAsync(new ModelTraining
            (
                id: Guid.Parse("c05eb2a2-8715-49b6-8c9d-ec885f121834"),
                type: 1380763569,
                path: "5848b00c8aac4e3",
                dataSource: 984928442,
                databaseConnectionString: "430ec224540",
                documentsDirectoryPath: "790770d5f97f4f75a108dad1939d099fde7e812418f84bab9bb97ce7ca16f7bf06f26c0bbad64009864f",
                mode: 472776852,
                trainingLog: "ca9afee295a2473892d2dc34f08f2dbb532"
            ));

            await _modelTrainingRepository.InsertAsync(new ModelTraining
            (
                id: Guid.Parse("86b6111a-a2f8-475b-a104-308da386c7fd"),
                type: 1668403757,
                path: "a329a84638f94479aac206827c0e3c749f2f19ab239542068a2e80ae820d50bab16cfa9926e54696bbde",
                dataSource: 1717188556,
                databaseConnectionString: "6c3fb7cc26844fa688cbbac0975c6660ce3fa4c68bed49348a20c4931d4c515ed65556159d98493aa6a",
                documentsDirectoryPath: "b3d75815cc554321af6463a0ed73418f47470fd352804f868f5fe96a",
                mode: 730421599,
                trainingLog: "10280dd80a6d41f8846bf8cc77cfb"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}