using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace FileUploader.ModelTrainings
{
    public abstract class ModelTrainingBase : FullAuditedAggregateRoot<Guid>
    {
        public virtual int Type { get; set; }

        [CanBeNull]
        public virtual string? Path { get; set; }

        public virtual int DataSource { get; set; }

        [CanBeNull]
        public virtual string? DatabaseConnectionString { get; set; }

        [CanBeNull]
        public virtual string? DocumentsDirectoryPath { get; set; }

        public virtual int Mode { get; set; }

        [CanBeNull]
        public virtual string? TrainingLog { get; set; }

        protected ModelTrainingBase()
        {

        }

        public ModelTrainingBase(Guid id, int type, int dataSource, int mode, string? path = null, string? databaseConnectionString = null, string? documentsDirectoryPath = null, string? trainingLog = null)
        {

            Id = id;
            Type = type;
            DataSource = dataSource;
            Mode = mode;
            Path = path;
            DatabaseConnectionString = databaseConnectionString;
            DocumentsDirectoryPath = documentsDirectoryPath;
            TrainingLog = trainingLog;
        }

    }
}