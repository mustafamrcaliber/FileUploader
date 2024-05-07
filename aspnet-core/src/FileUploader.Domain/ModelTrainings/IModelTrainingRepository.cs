using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FileUploader.ModelTrainings
{
    public partial interface IModelTrainingRepository : IRepository<ModelTraining, Guid>
    {
        Task<List<ModelTraining>> GetListAsync(
            string? filterText = null,
            int? typeMin = null,
            int? typeMax = null,
            string? path = null,
            int? dataSourceMin = null,
            int? dataSourceMax = null,
            string? databaseConnectionString = null,
            string? documentsDirectoryPath = null,
            int? modeMin = null,
            int? modeMax = null,
            string? trainingLog = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? typeMin = null,
            int? typeMax = null,
            string? path = null,
            int? dataSourceMin = null,
            int? dataSourceMax = null,
            string? databaseConnectionString = null,
            string? documentsDirectoryPath = null,
            int? modeMin = null,
            int? modeMax = null,
            string? trainingLog = null,
            CancellationToken cancellationToken = default);
    }
}