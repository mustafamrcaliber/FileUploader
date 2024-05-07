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
    public class ModelTraining : ModelTrainingBase
    {
        //<suite-custom-code-autogenerated>
        protected ModelTraining()
        {

        }

        public ModelTraining(Guid id, int type, int dataSource, int mode, string? path = null, string? databaseConnectionString = null, string? documentsDirectoryPath = null, string? trainingLog = null)
            : base(id, type, dataSource, mode, path, databaseConnectionString, documentsDirectoryPath, trainingLog)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}