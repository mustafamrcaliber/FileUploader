import type { IFormFile } from '../microsoft/asp-net-core/http/models';

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
