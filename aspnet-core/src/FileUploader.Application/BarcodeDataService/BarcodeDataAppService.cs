using System;
using System.Net.Http;
using System.Threading.Tasks;
using FileUploader.Models.ReportModals;
using Newtonsoft.Json;

namespace FileUploader.BarcodeData
{
    public class BarcodeDataAppService : FileUploaderAppService, IBarcodeDataAppService
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<ReportModal> GetReportingData(
            string? ElementName,
            Boolean? Filtering = false,
            dynamic? FilteringData = null
        )
        {
            string responseBody = "Failed";
            using HttpResponseMessage response = await client.GetAsync(
                "https://localhost:44325/api/app/report/reporting-data?Filtering=false"
            );
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            ReportModal result = JsonConvert.DeserializeObject<ReportModal>(responseBody);
            return result;
        }

        public async Task<CountOfUsagesModal> GetCountOfUsages()
        {
            string responseBody = "Failed";
            using HttpResponseMessage response = await client.GetAsync(
                "https://localhost:44325/Report/GetCountOfUsages"
            );
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            CountOfUsagesModal result = JsonConvert.DeserializeObject<CountOfUsagesModal>(
                responseBody
            );
            try
            {
                string responseBody2 = "Failed";
                using HttpResponseMessage response2 = await client.GetAsync(
                    "https://localhost:44325/api/app/devices-maps"
                );
                response2.EnsureSuccessStatusCode();
                responseBody2 = await response2.Content.ReadAsStringAsync();
                DevicesMapsModal result2 = JsonConvert.DeserializeObject<DevicesMapsModal>(
                    responseBody2
                );
                result.TotalDeviceCount = result2.totalCount;
            }
            catch (Exception ex) { }
            return result;
        }

        public async Task<AreaLineChartModal> GetAreaChartDataForCallCount(string? ElementName)
        {
             string responseBody = "Failed";
            using HttpResponseMessage response = await client.GetAsync(
                @$"https://localhost:44325/api/app/report/area-chart-data-for-call-count?ElementName={ElementName}"
            );
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            AreaLineChartModal result = JsonConvert.DeserializeObject<AreaLineChartModal>(responseBody);
            return result;
        }
    }
}
