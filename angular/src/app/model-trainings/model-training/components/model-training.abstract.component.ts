import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import type { ModelTrainingDto } from '../../../proxy/model-trainings/models';
import { ModelTrainingViewService } from '../services/model-training.service';
import { ModelTrainingDetailViewService } from '../services/model-training-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractModelTrainingComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(ModelTrainingViewService);
  public readonly serviceDetail = inject(ModelTrainingDetailViewService);
  protected title = '::ModelTrainings';

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

  update(record: ModelTrainingDto) {
    this.serviceDetail.update(record);
  }

  delete(record: ModelTrainingDto) {
    this.service.delete(record);
  }
}
