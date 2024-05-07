using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FileUploader.ModelRegistrations
{
    public partial interface IModelRegistrationRepository : IRepository<ModelRegistration, Guid>
    {
        Task<List<ModelRegistration>> GetListAsync(
            string? filterText = null,
            int? modelMin = null,
            int? modelMax = null,
            string? apiPath = null,
            string? localPath = null,
            int? scheduleMin = null,
            int? scheduleMax = null,
            double? intervalMin = null,
            double? intervalMax = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? modelMin = null,
            int? modelMax = null,
            string? apiPath = null,
            string? localPath = null,
            int? scheduleMin = null,
            int? scheduleMax = null,
            double? intervalMin = null,
            double? intervalMax = null,
            CancellationToken cancellationToken = default);
    }
}