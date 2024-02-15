using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
namespace FileUploader.FileUploaderSaver
{
    public class UploadFileRequestModel
    {
        public string FilePath { get; set; }
        public IFormFile File { get; set; }
    }

    public class UploadFileResponseModel
    {
        public int FileUploadStatus { get; set; }
        public string ErrorMessage { get; set; } = "--";
        public string SuccessMessage { get; set; } = "--";
        public string? FileName { get; set; } = "--";
    }
    public class GetWholeDirectorySturctureResponseModel
    {
        public string FolderName { get; set; }
        public List<string> FileName { get; set; }
    }

    public class GetPMSampleDataResponse
    {
        public int? startSamplingCount { get; set; }
        public int? collectSamplingCount { get; set; }
        public int? incubationSamplingCount { get; set; }
        public int? observationSamplingCount { get; set; }
        public int? reviewSamplingCount { get; set; }
        public int? microbialSamplingCount { get; set; }
        public int? pmSamplesWaitingForVerification { get; set; }
        public int? samplesWaitingForSwabProcess { get; set; }
        public int? emSamplesWaitingForVerification { get; set; }
        public string? resultReviewInfo { get; set; }
        public string? samplingRunningInfo { get; set; }
        public int? emSamplesOut { get; set; }
        public int? pmSamplesOut { get; set; }
        public int? emSamplesIn { get; set; }
        public int? pmSamplesIn { get; set; }
        public int? emSampleOfTheDay { get; set; }
        public int? pmSampleOfTheDay { get; set; }
        public int? incCyclesOfTheDay { get; set; }
        public int? samplesVerifedOfTheDay { get; set; }
        public int? sampleReviewsOfTheDay { get; set; }
        public int? incCyclesEndOfTheDay { get; set; }
    }
    public class GetEmSampleDataResponse
    {
        public int? startSamplingCount { get; set; }
        public int? collectSamplingCount { get; set; }
        public int? incubationSamplingCount { get; set; }
        public int? observationSamplingCount { get; set; }
        public int? reviewSamplingCount { get; set; }
        public int? microbialSamplingCount { get; set; }
        public int? pmSamplesWaitingForVerification { get; set; }
        public int? samplesWaitingForSwabProcess { get; set; }
        public int? emSamplesWaitingForVerification { get; set; }
        public string? resultReviewInfo { get; set; }
        public string samplingRunningInfo { get; set; }
        public int? emSamplesOut { get; set; }
        public int? pmSamplesOut { get; set; }
        public int? emSamplesIn { get; set; }
        public int? pmSamplesIn { get; set; }
        public int? emSampleOfTheDay { get; set; }
        public int? pmSampleOfTheDay { get; set; }
        public int? incCyclesOfTheDay { get; set; }
        public int? samplesVerifedOfTheDay { get; set; }
        public int? sampleReviewsOfTheDay { get; set; }
        public int? incCyclesEndOfTheDay { get; set; }
    }
}
