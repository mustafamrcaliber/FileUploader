using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FileUploader.ModelConfigurations
{
    public abstract class ModelConfigurationCreateDtoBase
    {
        public string? SystemPrompt { get; set; }
        public double Temperature { get; set; }
        public string? TopK { get; set; }
        public string? TopP { get; set; }
        public string? RepeatPenalty { get; set; }
        public string? ContextLength { get; set; }
        public string? MaxTokens { get; set; }
    }
}