import { Injectable, inject } from '@angular/core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { ABP, ListService, PagedResultDto } from '@abp/ng.core';
import { filter, switchMap } from 'rxjs/operators';
import type {
  GetModelTrainingsInput,
  ModelTrainingDto,
} from '../../../proxy/model-trainings/models';
import { ModelTrainingService } from '../../../proxy/model-trainings/model-training.service';

export abstract class AbstractModelTrainingViewService {
  protected readonly proxyService = inject(ModelTrainingService);
  protected readonly confirmationService = inject(ConfirmationService);
  protected readonly list = inject(ListService);

  data: PagedResultDto<ModelTrainingDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetModelTrainingsInput;

  delete(record: ModelTrainingDto) {
    this.confirmationService
      .warn('::DeleteConfirmationMessage', '::AreYouSure', { messageLocalizationParams: [] })
      .pipe(
        filter(status => status === Confirmation.Status.confirm),
        switchMap(() => this.proxyService.delete(record.id))
      )
      .subscribe(this.list.get);
  }

  hookToQuery() {
    const getData = (query: ABP.PageQueryParams) =>
      this.proxyService.getList({
        ...query,
        ...this.filters,
        filterText: query.filter,
      });

    const setData = (list: PagedResultDto<ModelTrainingDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetModelTrainingsInput;
    this.list.get();
  }
}
