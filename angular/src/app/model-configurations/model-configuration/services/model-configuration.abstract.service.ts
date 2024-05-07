import { Injectable, inject } from '@angular/core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { ABP, ListService, PagedResultDto } from '@abp/ng.core';
import { filter, switchMap } from 'rxjs/operators';
import type {
  GetModelConfigurationsInput,
  ModelConfigurationDto,
} from '../../../proxy/model-configurations/models';
import { ModelConfigurationService } from '../../../proxy/model-configurations/model-configuration.service';

export abstract class AbstractModelConfigurationViewService {
  protected readonly proxyService = inject(ModelConfigurationService);
  protected readonly confirmationService = inject(ConfirmationService);
  protected readonly list = inject(ListService);

  data: PagedResultDto<ModelConfigurationDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetModelConfigurationsInput;

  delete(record: ModelConfigurationDto) {
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

    const setData = (list: PagedResultDto<ModelConfigurationDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetModelConfigurationsInput;
    this.list.get();
  }
}
