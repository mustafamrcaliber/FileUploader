using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FileUploader.ModelRegistrations
{
    public abstract class ModelRegistrationDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public int Model { get; set; }
        public string? ApiPath { get; set; }
        public string? LocalPath { get; set; }
        public int Schedule { get; set; }
        public double Interval { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}