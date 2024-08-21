import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetModelRegistrationsInput extends GetModelRegistrationsInputBase {
}

export interface GetModelRegistrationsInputBase extends PagedAndSortedResultRequestDto {
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

export interface ModelRegistrationCreateDto extends ModelRegistrationCreateDtoBase {
}

export interface ModelRegistrationCreateDtoBase {
  model: number;
  apiPath?: string;
  localPath?: string;
  schedule: number;
  interval: number;
}

export interface ModelRegistrationDto extends ModelRegistrationDtoBase {
}

export interface ModelRegistrationDtoBase extends FullAuditedEntityDto<string> {
  model: number;
  apiPath?: string;
  localPath?: string;
  schedule: number;
  interval: number;
  concurrencyStamp?: string;
}

export interface ModelRegistrationUpdateDto extends ModelRegistrationUpdateDtoBase {
}

export interface ModelRegistrationUpdateDtoBase {
  model: number;
  apiPath?: string;
  localPath?: string;
  schedule: number;
  interval: number;
  concurrencyStamp?: string;
}
