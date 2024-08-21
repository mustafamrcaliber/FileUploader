using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace FileUploader.ModelConfigurations
{
    public abstract class ModelConfigurationUpdateDtoBase : IHasConcurrencyStamp
    {
        public string? SystemPrompt { get; set; }
        public double Temperature { get; set; }
        public string? TopK { get; set; }
        public string? TopP { get; set; }
        public string? RepeatPenalty { get; set; }
        public string? ContextLength { get; set; }
        public string? MaxTokens { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}