import type { IFormFile } from '../microsoft/asp-net-core/http/models';

export interface GetEmSampleDataResponse {
  startSamplingCount?: number;
  collectSamplingCount?: number;
  incubationSamplingCount?: number;
  observationSamplingCount?: number;
  reviewSamplingCount?: number;
  microbialSamplingCount?: number;
  pmSamplesWaitingForVerification?: number;
  samplesWaitingForSwabProcess?: number;
  emSamplesWaitingForVerification?: number;
  resultReviewInfo?: number;
  samplingRunningInfo?: string;
  emSamplesOut?: number;
  pmSamplesOut?: number;
  emSamplesIn?: number;
  pmSamplesIn?: number;
  emSampleOfTheDay?: number;
  pmSampleOfTheDay?: number;
  incCyclesOfTheDay?: number;
  samplesVerifedOfTheDay?: number;
  sampleReviewsOfTheDay?: number;
  incCyclesEndOfTheDay?: number;
}

export interface GetPMSampleDataResponse {
  startSamplingCount?: number;
  collectSamplingCount?: number;
  incubationSamplingCount?: number;
  observationSamplingCount?: number;
  reviewSamplingCount?: number;
  microbialSamplingCount?: number;
  pmSamplesWaitingForVerification?: number;
  samplesWaitingForSwabProcess?: number;
  emSamplesWaitingForVerification?: number;
  resultReviewInfo?: number;
  samplingRunningInfo?: number;
  emSamplesOut?: number;
  pmSamplesOut?: number;
  emSamplesIn?: number;
  pmSamplesIn?: number;
  emSampleOfTheDay?: number;
  pmSampleOfTheDay?: number;
  incCyclesOfTheDay?: number;
  samplesVerifedOfTheDay?: number;
  sampleReviewsOfTheDay?: number;
  incCyclesEndOfTheDay?: number;
}

export interface GetWholeDirectorySturctureResponseModel {
  folderName?: string;
  fileName: string[];
}

export interface UploadFileRequestModel {
  filePath?: string;
  file: File;
}

export interface UploadFileResponseModel {
  fileUploadStatus: number;
  errorMessage?: string;
  successMessage?: string;
  fileName?: string;
}
