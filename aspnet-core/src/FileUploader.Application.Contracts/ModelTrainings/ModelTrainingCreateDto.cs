using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FileUploader.ModelTrainings
{
    public abstract class ModelTrainingCreateDtoBase
    {
        public int Type { get; set; }
        public string? Path { get; set; }
        public int DataSource { get; set; }
        public string? DatabaseConnectionString { get; set; } = "--";
        public string? DocumentsDirectoryPath { get; set; } = "--";
        public int Mode { get; set; }
        public string? TrainingLog { get; set; }
    }
}