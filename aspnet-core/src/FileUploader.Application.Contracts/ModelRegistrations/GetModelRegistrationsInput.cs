using Volo.Abp.Application.Dtos;
using System;

namespace FileUploader.ModelRegistrations
{
    public abstract class GetModelRegistrationsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public int? ModelMin { get; set; }
        public int? ModelMax { get; set; }
        public string? ApiPath { get; set; }
        public string? LocalPath { get; set; }
        public int? ScheduleMin { get; set; }
        public int? ScheduleMax { get; set; }
        public double? IntervalMin { get; set; }
        public double? IntervalMax { get; set; }

        public GetModelRegistrationsInputBase()
        {

        }
    }
}