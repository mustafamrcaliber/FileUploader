using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace FileUploader.Models.ReportModals
{
    public class Chart
    {
        public int width { get; set; } = 380;
        public string type { get; set; } = "";
    }

    public class Legend
    {
        public string position { get; set; } = "bottom";
    }

    public class Options
    {
        public Chart chart { get; set; }
        public Legend legend { get; set; }
    }

    public class Responsive
    {
        public int breakpoint { get; set; } = 480;
        public Options options { get; set; }
    }

    public class PieChartModal
    {
        public List<int> series { get; set; }
        public Chart chart { get; set; }
        public List<string> labels { get; set; }
        public List<Responsive> responsive { get; set; }
    }

    public class HitCountByElementName
    {
        public int HitCount { get; set; }
        public string ElementName { get; set; }
    }

    public class HitMaxYearMonthWise
    {
        public int Hit { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
    }

    public class Series
    {
        public string name { get; set; }
        public List<int> data { get; set; }
    }

    public class MaxAndMinExecutionTimeMonthwiseModal
    {
        public int MaxTime { get; set; }
        public int MinTime { get; set; }
        public string Month { get; set; }
    }

    public class DeviceCountByCategoryModal
    {
        public int DeviceCount { get; set; }
        public string CategoryName { get; set; }
    }

    public class ElementReportModal
    {
        public string RuleEngineId { get; set; }
        public string RuleEngineDetailsJson { get; set; }
        public string TopicData { get; set; }
        public DateTime CreationTime { get; set; }
        public string FinalPassingElementData { get; set; }
    }

    public class ReportModal
    {
        public List<string> ColumnsName { get; set; }
        public List<ListItrationModal> ListItration { get; set; }
    }

    public class ListItrationModal
    {
        public DateTime CallExecutionTime { get; set; }
        public List<ColumnDataValueModal> ColumnValue { get; set; }
    }

    public class ColumnDataValueModal
    {
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
    }

    public class TimeSeriesDataModal
    {
        public dynamic Count { get; set; }
        public dynamic Unixtime { get; set; }
    }

    public class AreaLineChartModal
    {
        public List<string> Categories { get; set; }
        public List<Series> Series { get; set; }
    }

    public class AreaLineCountReturnModal
    {
        public string Categories { get; set; }
        public int Data { get; set; }
        public string Series { get; set; }
    }

    public class FilteringDataModal
    {
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? MoreFilterData { get; set; }
    }

    public class DateFilterModal
    {
        public string? FromDate { get; set; } = null;
        public string? ToDate { get; set; } = null;

    }

    public class DateDataFormaterModal
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
    }

    public class AttributeAndAttrValuesModal{
        public string? AttributeName { get; set; }
        public List<string>? AttrValuesList { get; set; }
    }

    public class MoreFilterDataModal{
        public string? AttributeName { get; set; }
        public string? AttrValue { get; set; }
    }

    public class CountOfUsagesModal{
        public int? TotalDeviceCount { get; set; } = 0;
        public int ReservedCount { get; set; } = 0;
        public int AvailableCount { get; set; } = 0;
        public int CalibratedCount { get; set; } = 0;
        public int NotCalibratedCount { get; set; } = 0;
        public int ProblemReportedCount { get; set; } = 0;
    }

    public class DevicesMapsModal
    {
        public int totalCount { get; set; }
    }
}
