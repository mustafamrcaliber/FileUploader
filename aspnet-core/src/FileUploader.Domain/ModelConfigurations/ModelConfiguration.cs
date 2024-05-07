using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace FileUploader.ModelConfigurations
{
    public abstract class ModelConfigurationBase : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string? SystemPrompt { get; set; }

        public virtual double Temperature { get; set; }

        [CanBeNull]
        public virtual string? TopK { get; set; }

        [CanBeNull]
        public virtual string? TopP { get; set; }

        [CanBeNull]
        public virtual string? RepeatPenalty { get; set; }

        [CanBeNull]
        public virtual string? ContextLength { get; set; }

        [CanBeNull]
        public virtual string? MaxTokens { get; set; }

        protected ModelConfigurationBase()
        {

        }

        public ModelConfigurationBase(Guid id, double temperature, string? systemPrompt = null, string? topK = null, string? topP = null, string? repeatPenalty = null, string? contextLength = null, string? maxTokens = null)
        {

            Id = id;
            Temperature = temperature;
            SystemPrompt = systemPrompt;
            TopK = topK;
            TopP = topP;
            RepeatPenalty = repeatPenalty;
            ContextLength = contextLength;
            MaxTokens = maxTokens;
        }

    }
}