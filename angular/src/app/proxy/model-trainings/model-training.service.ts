import type {
  GetModelTrainingsInput,
  ModelTrainingCreateDto,
  ModelTrainingDto,
  ModelTrainingUpdateDto,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ModelTrainingService {
  apiName = 'Default';

  create = (input: ModelTrainingCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelTrainingDto>(
      {
        method: 'POST',
        url: '/api/app/model-trainings',
        body: input,
      },
      { apiName: this.apiName, ...config }
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/app/model-trainings/${id}`,
      },
      { apiName: this.apiName, ...config }
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelTrainingDto>(
      {
        method: 'GET',
        url: `/api/app/model-trainings/${id}`,
      },
      { apiName: this.apiName, ...config }
    );

  getList = (input: GetModelTrainingsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ModelTrainingDto>>(
      {
        method: 'GET',
        url: '/api/app/model-trainings',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          typeMin: input.typeMin,
          typeMax: input.typeMax,
          path: input.path,
          dataSourceMin: input.dataSourceMin,
          dataSourceMax: input.dataSourceMax,
          databaseConnectionString: input.databaseConnectionString,
          documentsDirectoryPath: input.documentsDirectoryPath,
          modeMin: input.modeMin,
          modeMax: input.modeMax,
          trainingLog: input.trainingLog,
        },
      },
      { apiName: this.apiName, ...config }
    );

  update = (id: string, input: ModelTrainingUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ModelTrainingDto>(
      {
        method: 'PUT',
        url: `/api/app/model-trainings/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config }
    );

  constructor(private restService: RestService) {}
}
