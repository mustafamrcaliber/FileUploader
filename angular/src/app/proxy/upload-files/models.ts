import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetUploadFilesInput extends GetUploadFilesInputBase {
}

export interface GetUploadFilesInputBase extends PagedAndSortedResultRequestDto {
  filterText?: string;
  fileName?: string;
  filePath?: string;
  fileType?: string;
  fileSize?: string;
}

export interface UploadFileCreateDto extends UploadFileCreateDtoBase {
}

export interface UploadFileCreateDtoBase {
  fileName?: string;
  filePath?: string;
  fileType?: string;
  fileSize?: string;
}

export interface UploadFileDto extends UploadFileDtoBase {
}

export interface UploadFileDtoBase extends FullAuditedEntityDto<string> {
  fileName?: string;
  filePath?: string;
  fileType?: string;
  fileSize?: string;
  concurrencyStamp?: string;
}

export interface UploadFileExcelDownloadDto extends UploadFileExcelDownloadDtoBase {
}

export interface UploadFileExcelDownloadDtoBase {
  downloadToken?: string;
  filterText?: string;
  fileName?: string;
  filePath?: string;
  fileType?: string;
  fileSize?: string;
}

export interface UploadFileUpdateDto extends UploadFileUpdateDtoBase {
}

export interface UploadFileUpdateDtoBase {
  fileName?: string;
  filePath?: string;
  fileType?: string;
  fileSize?: string;
  concurrencyStamp?: string;
}
