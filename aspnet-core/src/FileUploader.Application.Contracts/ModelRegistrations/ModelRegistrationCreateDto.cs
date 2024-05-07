using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FileUploader.ModelRegistrations
{
    public abstract class ModelRegistrationCreateDtoBase
    {
        public int Model { get; set; } = 0;
        public string? ApiPath { get; set; } = "--";
        public string? LocalPath { get; set; } = "--";
        public int Schedule { get; set; } = 0;
        public double Interval { get; set; }
    }
}