import type { GetWholeDirectorySturctureResponseModel, UploadFileRequestModel, UploadFileResponseModel } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class FileUploaderSaverService {
  apiName = 'Default';
  

  getWholeDirectorySturcture = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, GetWholeDirectorySturctureResponseModel[]>({
      method: 'GET',
      url: '/api/app/file-uploader-saver/whole-directory-sturcture',
    },
    { apiName: this.apiName,...config });
  

  uploadFileByFileData = (FileData: UploadFileRequestModel, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UploadFileResponseModel>({
      method: 'POST',
      url: '/api/app/file-uploader-saver/upload-file',
      body: FileData,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
