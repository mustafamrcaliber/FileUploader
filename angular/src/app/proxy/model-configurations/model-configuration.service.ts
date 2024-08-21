import type { GetModelConfigurationsInput, ModelConfigurationCreateDto, ModelConfigurationDto, ModelConfigurationUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ModelConfigurationService {
  apiName = 'Default';
  

  create = (input: ModelConfigurationCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelConfigurationDto>({
      method: 'POST',
      url: '/api/app/model-configurations',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/model-configurations/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelConfigurationDto>({
      method: 'GET',
      url: `/api/app/model-configurations/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetModelConfigurationsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ModelConfigurationDto>>({
      method: 'GET',
      url: '/api/app/model-configurations',
      params: { filterText: input.filterText, systemPrompt: input.systemPrompt, temperatureMin: input.temperatureMin, temperatureMax: input.temperatureMax, topK: input.topK, topP: input.topP, repeatPenalty: input.repeatPenalty, contextLength: input.contextLength, maxTokens: input.maxTokens, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: ModelConfigurationUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelConfigurationDto>({
      method: 'PUT',
      url: `/api/app/model-configurations/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
