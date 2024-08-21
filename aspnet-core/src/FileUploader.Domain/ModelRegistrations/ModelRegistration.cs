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
    public abstract class ModelRegistrationBase : FullAuditedAggregateRoot<Guid>
    {
        public virtual int Model { get; set; }

        [CanBeNull]
        public virtual string? ApiPath { get; set; }

        [CanBeNull]
        public virtual string? LocalPath { get; set; }

        public virtual int Schedule { get; set; }

        public virtual double Interval { get; set; }

        protected ModelRegistrationBase()
        {

        }

        public ModelRegistrationBase(Guid id, int model, int schedule, double interval, string? apiPath = null, string? localPath = null)
        {

            Id = id;
            Model = model;
            Schedule = schedule;
            Interval = interval;
            ApiPath = apiPath;
            LocalPath = localPath;
        }

    }
}