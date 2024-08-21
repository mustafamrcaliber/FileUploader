using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FileUploader.ModelConfigurations
{
    public partial interface IModelConfigurationRepository : IRepository<ModelConfiguration, Guid>
    {
        Task<List<ModelConfiguration>> GetListAsync(
            string? filterText = null,
            string? systemPrompt = null,
            double? temperatureMin = null,
            double? temperatureMax = null,
            string? topK = null,
            string? topP = null,
            string? repeatPenalty = null,
            string? contextLength = null,
            string? maxTokens = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? systemPrompt = null,
            double? temperatureMin = null,
            double? temperatureMax = null,
            string? topK = null,
            string? topP = null,
            string? repeatPenalty = null,
            string? contextLength = null,
            string? maxTokens = null,
            CancellationToken cancellationToken = default);
    }
}