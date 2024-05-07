import { Injectable, inject } from '@angular/core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { ABP, ListService, PagedResultDto } from '@abp/ng.core';
import { filter, switchMap } from 'rxjs/operators';
import type {
  GetModelRegistrationsInput,
  ModelRegistrationDto,
} from '../../../proxy/model-registrations/models';
import { ModelRegistrationService } from '../../../proxy/model-registrations/model-registration.service';

export abstract class AbstractModelRegistrationViewService {
  protected readonly proxyService = inject(ModelRegistrationService);
  protected readonly confirmationService = inject(ConfirmationService);
  protected readonly list = inject(ListService);

  data: PagedResultDto<ModelRegistrationDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetModelRegistrationsInput;

  delete(record: ModelRegistrationDto) {
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

    const setData = (list: PagedResultDto<ModelRegistrationDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetModelRegistrationsInput;
    this.list.get();
  }
}
