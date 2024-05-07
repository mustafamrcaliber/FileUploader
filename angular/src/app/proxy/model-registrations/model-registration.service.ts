import type {
  GetModelRegistrationsInput,
  ModelRegistrationCreateDto,
  ModelRegistrationDto,
  ModelRegistrationUpdateDto,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ModelRegistrationService {
  apiName = 'Default';

  create = (input: ModelRegistrationCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelRegistrationDto>(
      {
        method: 'POST',
        url: '/api/app/model-registrations',
        body: input,
      },
      { apiName: this.apiName, ...config }
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/app/model-registrations/${id}`,
      },
      { apiName: this.apiName, ...config }
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelRegistrationDto>(
      {
        method: 'GET',
        url: `/api/app/model-registrations/${id}`,
      },
      { apiName: this.apiName, ...config }
    );

  getList = (input: GetModelRegistrationsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ModelRegistrationDto>>(
      {
        method: 'GET',
        url: '/api/app/model-registrations',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          modelMin: input.modelMin,
          modelMax: input.modelMax,
          apiPath: input.apiPath,
          localPath: input.localPath,
          scheduleMin: input.scheduleMin,
          scheduleMax: input.scheduleMax,
          intervalMin: input.intervalMin,
          intervalMax: input.intervalMax,
        },
      },
      { apiName: this.apiName, ...config }
    );

  update = (id: string, input: ModelRegistrationUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelRegistrationDto>(
      {
        method: 'PUT',
        url: `/api/app/model-registrations/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config }
    );

  constructor(private restService: RestService) {}
}
