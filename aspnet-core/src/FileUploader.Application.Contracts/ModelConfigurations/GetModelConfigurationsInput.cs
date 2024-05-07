using Volo.Abp.Application.Dtos;
using System;

namespace FileUploader.ModelConfigurations
{
    public abstract class GetModelConfigurationsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? SystemPrompt { get; set; }
        public double? TemperatureMin { get; set; }
        public double? TemperatureMax { get; set; }
        public string? TopK { get; set; }
        public string? TopP { get; set; }
        public string? RepeatPenalty { get; set; }
        public string? ContextLength { get; set; }
        public string? MaxTokens { get; set; }

        public GetModelConfigurationsInputBase()
        {

        }
    }
}