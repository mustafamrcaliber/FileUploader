using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace FileUploader.ModelRegistrations
{
    public class ModelRegistration : ModelRegistrationBase
    {
        //<suite-custom-code-autogenerated>
        protected ModelRegistration()
        {

        }

        public ModelRegistration(Guid id, int model, int schedule, double interval, string? apiPath = null, string? localPath = null)
            : base(id, model, schedule, interval, apiPath, localPath)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}