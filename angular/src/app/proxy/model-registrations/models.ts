import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetModelRegistrationsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  modelMin?: number;
  modelMax?: number;
  apiPath?: string;
  localPath?: string;
  scheduleMin?: number;
  scheduleMax?: number;
  intervalMin?: number;
  intervalMax?: number;
}

export interface ModelRegistrationCreateDto {
  model?: number;
  apiPath?: string;
  localPath?: string;
  schedule?: number;
  interval?: number;
}

export interface ModelRegistrationDto extends FullAuditedEntityDto<string> {
  model?: number;
  apiPath?: string;
  localPath?: string;
  schedule?: number;
  interval?: number;
  concurrencyStamp?: string;
}

export interface ModelRegistrationUpdateDto {
  model?: number;
  apiPath?: string;
  localPath?: string;
  schedule?: number;
  interval?: number;
  concurrencyStamp?: string;
}
