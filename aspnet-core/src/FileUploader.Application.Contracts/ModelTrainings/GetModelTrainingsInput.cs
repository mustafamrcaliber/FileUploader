using Volo.Abp.Application.Dtos;
using System;

namespace FileUploader.ModelTrainings
{
    public abstract class GetModelTrainingsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public int? TypeMin { get; set; }
        public int? TypeMax { get; set; }
        public string? Path { get; set; }
        public int? DataSourceMin { get; set; }
        public int? DataSourceMax { get; set; }
        public string? DatabaseConnectionString { get; set; }
        public string? DocumentsDirectoryPath { get; set; }
        public int? ModeMin { get; set; }
        public int? ModeMax { get; set; }
        public string? TrainingLog { get; set; }

        public GetModelTrainingsInputBase()
        {

        }
    }
}