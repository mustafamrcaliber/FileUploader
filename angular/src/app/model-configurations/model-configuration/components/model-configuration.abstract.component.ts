import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import type { ModelConfigurationDto } from '../../../proxy/model-configurations/models';
import { ModelConfigurationViewService } from '../services/model-configuration.service';
import { ModelConfigurationDetailViewService } from '../services/model-configuration-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractModelConfigurationComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(ModelConfigurationViewService);
  public readonly serviceDetail = inject(ModelConfigurationDetailViewService);
  protected title = '::ModelConfigurations';

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

  update(record: ModelConfigurationDto) {
    this.serviceDetail.update(record);
  }

  delete(record: ModelConfigurationDto) {
    this.service.delete(record);
  }
}
