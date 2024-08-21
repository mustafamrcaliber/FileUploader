import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import type { ModelRegistrationDto } from '../../../proxy/model-registrations/models';
import { ModelRegistrationViewService } from '../services/model-registration.service';
import { ModelRegistrationDetailViewService } from '../services/model-registration-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractModelRegistrationComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(ModelRegistrationViewService);
  public readonly serviceDetail = inject(ModelRegistrationDetailViewService);
  protected title = '::ModelRegistrations';

  ngOnInit() {
    this.service.hookToQuery();
  }

  clearFilters() {
    this.service.clearFilters();
  }

  showForm() {
    this.serviceDetail.showForm();
  }

  create() {
    this.serviceDetail.selected = undefined;
    this.serviceDetail.showForm();
  }

  update(record: ModelRegistrationDto) {
    this.serviceDetail.update(record);
  }

  delete(record: ModelRegistrationDto) {
    this.service.delete(record);
  }
}
