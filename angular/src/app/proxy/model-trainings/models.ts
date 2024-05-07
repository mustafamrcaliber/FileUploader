import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetModelTrainingsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  typeMin?: number;
  typeMax?: number;
  path?: string;
  dataSourceMin?: number;
  dataSourceMax?: number;
  databaseConnectionString?: string;
  documentsDirectoryPath?: string;
  modeMin?: number;
  modeMax?: number;
  trainingLog?: string;
}

export interface ModelTrainingCreateDto {
  type?: number;
  path?: string;
  dataSource?: number;
  databaseConnectionString?: string;
  documentsDirectoryPath?: string;
  mode?: number;
  trainingLog?: string;
}

export interface ModelTrainingDto extends FullAuditedEntityDto<string> {
  type?: number;
  path?: string;
  dataSource?: number;
  databaseConnectionString?: string;
  documentsDirectoryPath?: string;
  mode?: number;
  trainingLog?: string;
  concurrencyStamp?: string;
}

export interface ModelTrainingUpdateDto {
  type?: number;
  path?: string;
  dataSource?: number;
  databaseConnectionString?: string;
  documentsDirectoryPath?: string;
  mode?: number;
  trainingLog?: string;
  concurrencyStamp?: string;
}
