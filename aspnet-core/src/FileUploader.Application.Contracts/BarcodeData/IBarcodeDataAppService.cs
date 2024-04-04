using System;
using System.Threading.Tasks;
using FileUploader.Models.ReportModals;

namespace  FileUploader.BarcodeData
{
    public interface IBarcodeDataAppService
    {
        public Task<ReportModal> GetReportingData(
            string? ElementName,
            Boolean? Filtering = false,
            dynamic? FilteringData = null
        );
        public Task<CountOfUsagesModal> GetCountOfUsages();

        public Task<AreaLineChartModal> GetAreaChartDataForCallCount(string? ElementName);
    }
}
