import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetModelTrainingsInput extends GetModelTrainingsInputBase {
}

export interface GetModelTrainingsInputBase extends PagedAndSortedResultRequestDto {
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

export interface ModelTrainingCreateDto extends ModelTrainingCreateDtoBase {
}

export interface ModelTrainingCreateDtoBase {
  type: number;
  path?: string;
  dataSource: number;
  databaseConnectionString?: string;
  documentsDirectoryPath?: string;
  mode: number;
  trainingLog?: string;
}

export interface ModelTrainingDto extends ModelTrainingDtoBase {
}

export interface ModelTrainingDtoBase extends FullAuditedEntityDto<string> {
  type: number;
  path?: string;
  dataSource: number;
  databaseConnectionString?: string;
  documentsDirectoryPath?: string;
  mode: number;
  trainingLog?: string;
  concurrencyStamp?: string;
}

export interface ModelTrainingUpdateDto extends ModelTrainingUpdateDtoBase {
}

export interface ModelTrainingUpdateDtoBase {
  type: number;
  path?: string;
  dataSource: number;
  databaseConnectionString?: string;
  documentsDirectoryPath?: string;
  mode: number;
  trainingLog?: string;
  concurrencyStamp?: string;
}
