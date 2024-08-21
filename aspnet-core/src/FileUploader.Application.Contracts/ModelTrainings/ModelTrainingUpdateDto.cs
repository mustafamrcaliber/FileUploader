using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace FileUploader.ModelTrainings
{
    public abstract class ModelTrainingUpdateDtoBase : IHasConcurrencyStamp
    {
        public int Type { get; set; }
        public string? Path { get; set; }
        public int DataSource { get; set; }
        public string? DatabaseConnectionString { get; set; }
        public string? DocumentsDirectoryPath { get; set; }
        public int Mode { get; set; }
        public string? TrainingLog { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}