using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using FileUploader.EntityFrameworkCore;

namespace FileUploader.ModelConfigurations
{
    public abstract class EfCoreModelConfigurationRepositoryBase : EfCoreRepository<FileUploaderDbContext, ModelConfiguration, Guid>
    {
        public EfCoreModelConfigurationRepositoryBase(IDbContextProvider<FileUploaderDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<ModelConfiguration>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, systemPrompt, temperatureMin, temperatureMax, topK, topP, repeatPenalty, contextLength, maxTokens);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ModelConfigurationConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? systemPrompt = null,
            double? temperatureMin = null,
            double? temperatureMax = null,
            string? topK = null,
            string? topP = null,
            string? repeatPenalty = null,
            string? contextLength = null,
            string? maxTokens = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, systemPrompt, temperatureMin, temperatureMax, topK, topP, repeatPenalty, contextLength, maxTokens);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ModelConfiguration> ApplyFilter(
            IQueryable<ModelConfiguration> query,
            string? filterText = null,
            string? systemPrompt = null,
            double? temperatureMin = null,
            double? temperatureMax = null,
            string? topK = null,
            string? topP = null,
            string? repeatPenalty = null,
            string? contextLength = null,
            string? maxTokens = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.SystemPrompt!.Contains(filterText!) || e.TopK!.Contains(filterText!) || e.TopP!.Contains(filterText!) || e.RepeatPenalty!.Contains(filterText!) || e.ContextLength!.Contains(filterText!) || e.MaxTokens!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(systemPrompt), e => e.SystemPrompt.Contains(systemPrompt))
                    .WhereIf(temperatureMin.HasValue, e => e.Temperature >= temperatureMin!.Value)
                    .WhereIf(temperatureMax.HasValue, e => e.Temperature <= temperatureMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(topK), e => e.TopK.Contains(topK))
                    .WhereIf(!string.IsNullOrWhiteSpace(topP), e => e.TopP.Contains(topP))
                    .WhereIf(!string.IsNullOrWhiteSpace(repeatPenalty), e => e.RepeatPenalty.Contains(repeatPenalty))
                    .WhereIf(!string.IsNullOrWhiteSpace(contextLength), e => e.ContextLength.Contains(contextLength))
                    .WhereIf(!string.IsNullOrWhiteSpace(maxTokens), e => e.MaxTokens.Contains(maxTokens));
        }
    }
}