import type { GetUploadFilesInput, UploadFileCreateDto, UploadFileDto, UploadFileExcelDownloadDto, UploadFileUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class UploadFileService {
  apiName = 'Default';
  

  create = (input: UploadFileCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UploadFileDto>({
      method: 'POST',
      url: '/api/app/upload-files',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/upload-files/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UploadFileDto>({
      method: 'GET',
      url: `/api/app/upload-files/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/upload-files/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetUploadFilesInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<UploadFileDto>>({
      method: 'GET',
      url: '/api/app/upload-files',
      params: { filterText: input.filterText, fileName: input.fileName, filePath: input.filePath, fileType: input.fileType, fileSize: input.fileSize, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: UploadFileExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/upload-files/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, fileName: input.fileName, filePath: input.filePath, fileType: input.fileType, fileSize: input.fileSize },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: UploadFileUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, UploadFileDto>({
      method: 'PUT',
      url: `/api/app/upload-files/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
