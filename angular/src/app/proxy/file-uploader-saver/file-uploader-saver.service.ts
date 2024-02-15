import type { GetEmSampleDataResponse, GetPMSampleDataResponse, GetWholeDirectorySturctureResponseModel, UploadFileRequestModel, UploadFileResponseModel } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class FileUploaderSaverService {
  apiName = 'Default';
  

  getEmSampleData = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, GetEmSampleDataResponse[]>({
      method: 'GET',
      url: '/api/app/file-uploader-saver/em-sample-data',
    },
    { apiName: this.apiName,...config });
  

  getListOfFilesFromDir = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, string[]>({
      method: 'GET',
      url: '/api/app/file-uploader-saver/of-files-from-dir',
    },
    { apiName: this.apiName,...config });
  

  getPMSampleData = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, GetPMSampleDataResponse[]>({
      method: 'GET',
      url: '/api/app/file-uploader-saver/p-mSample-data',
    },
    { apiName: this.apiName,...config });
  

  getUrlToUploadFile = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'GET',
      responseType: 'text',
      url: '/api/app/file-uploader-saver/url-to-upload-file',
    },
    { apiName: this.apiName,...config });
  

  getWholeDirectorySturcture = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, GetWholeDirectorySturctureResponseModel[]>({
      method: 'GET',
      url: '/api/app/file-uploader-saver/whole-directory-sturcture',
    },
    { apiName: this.apiName,...config });
  

  sendUserMessageToApiAndGetJsonChartByMessage = (Message: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: '/api/app/file-uploader-saver/send-user-message-to-api-and-get-json-chart',
      params: { message: Message },
    },
    { apiName: this.apiName,...config });
  

  sendUserMessageToApiByMessage = (Message: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: '/api/app/file-uploader-saver/send-user-message-to-api',
      params: { message: Message },
    },
    { apiName: this.apiName,...config });
  

  uploadFileByFileData = (FileData: UploadFileRequestModel, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UploadFileResponseModel>({
      method: 'POST',
      url: '/api/app/file-uploader-saver/upload-file',
      body: FileData,
    },
    { apiName: this.apiName,...config });
  

  uploadFileToChatByFileName = (FileName: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: '/api/app/file-uploader-saver/upload-file-to-chat',
      params: { fileName: FileName },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
