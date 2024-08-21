import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetModelConfigurationsInput extends GetModelConfigurationsInputBase {
}

export interface GetModelConfigurationsInputBase extends PagedAndSortedResultRequestDto {
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

export interface ModelConfigurationCreateDto extends ModelConfigurationCreateDtoBase {
}

export interface ModelConfigurationCreateDtoBase {
  systemPrompt?: string;
  temperature: number;
  topK?: string;
  topP?: string;
  repeatPenalty?: string;
  contextLength?: string;
  maxTokens?: string;
}

export interface ModelConfigurationDto extends ModelConfigurationDtoBase {
}

export interface ModelConfigurationDtoBase extends FullAuditedEntityDto<string> {
  systemPrompt?: string;
  temperature: number;
  topK?: string;
  topP?: string;
  repeatPenalty?: string;
  contextLength?: string;
  maxTokens?: string;
  concurrencyStamp?: string;
}

export interface ModelConfigurationUpdateDto extends ModelConfigurationUpdateDtoBase {
}

export interface ModelConfigurationUpdateDtoBase {
  systemPrompt?: string;
  temperature: number;
  topK?: string;
  topP?: string;
  repeatPenalty?: string;
  contextLength?: string;
  maxTokens?: string;
  concurrencyStamp?: string;
}
