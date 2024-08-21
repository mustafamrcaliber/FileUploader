using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace FileUploader.ModelRegistrations
{
    public abstract class ModelRegistrationUpdateDtoBase : IHasConcurrencyStamp
    {
        public int Model { get; set; }
        public string? ApiPath { get; set; }
        public string? LocalPath { get; set; }
        public int Schedule { get; set; }
        public double Interval { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}