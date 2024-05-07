using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace FileUploader.ModelTrainings
{
    public abstract class ModelTrainingManagerBase : DomainService
    {
        protected IModelTrainingRepository _modelTrainingRepository;

        public ModelTrainingManagerBase(IModelTrainingRepository modelTrainingRepository)
        {
            _modelTrainingRepository = modelTrainingRepository;
        }

        public virtual async Task<ModelTraining> CreateAsync(
        int type, int dataSource, int mode, string? path = null, string? databaseConnectionString = null, string? documentsDirectoryPath = null, string? trainingLog = null)
        {

            var modelTraining = new ModelTraining(
             GuidGenerator.Create(),
             type, dataSource, mode, path, databaseConnectionString, documentsDirectoryPath, trainingLog
             );

            return await _modelTrainingRepository.InsertAsync(modelTraining);
        }

        public virtual async Task<ModelTraining> UpdateAsync(
            Guid id,
            int type, int dataSource, int mode, string? path = null, string? databaseConnectionString = null, string? documentsDirectoryPath = null, string? trainingLog = null, [CanBeNull] string? concurrencyStamp = null
        )
        {

            var modelTraining = await _modelTrainingRepository.GetAsync(id);

            modelTraining.Type = type;
            modelTraining.DataSource = dataSource;
            modelTraining.Mode = mode;
            modelTraining.Path = path;
            modelTraining.DatabaseConnectionString = databaseConnectionString;
            modelTraining.DocumentsDirectoryPath = documentsDirectoryPath;
            modelTraining.TrainingLog = trainingLog;

            modelTraining.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _modelTrainingRepository.UpdateAsync(modelTraining);
        }

    }
}