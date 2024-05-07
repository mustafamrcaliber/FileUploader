import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetModelConfigurationsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  systemPrompt?: string;
  temperatureMin?: number;
  temperatureMax?: number;
  topK?: string;
  topP?: string;
  repeatPenalty?: string;
  contextLength?: string;
  maxTokens?: string;
}

export interface ModelConfigurationCreateDto {
  systemPrompt?: string;
  temperature?: number;
  topK?: string;
  topP?: string;
  repeatPenalty?: string;
  contextLength?: string;
  maxTokens?: string;
}

export interface ModelConfigurationDto extends FullAuditedEntityDto<string> {
  systemPrompt?: string;
  temperature?: number;
  topK?: string;
  topP?: string;
  repeatPenalty?: string;
  contextLength?: string;
  maxTokens?: string;
  concurrencyStamp?: string;
}

export interface ModelConfigurationUpdateDto {
  systemPrompt?: string;
  temperature?: number;
  topK?: string;
  topP?: string;
  repeatPenalty?: string;
  contextLength?: string;
  maxTokens?: string;
  concurrencyStamp?: string;
}
