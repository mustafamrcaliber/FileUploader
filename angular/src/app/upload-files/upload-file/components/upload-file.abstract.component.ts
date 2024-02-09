import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import type { UploadFileDto } from '../../../proxy/upload-files/models';
import { UploadFileViewService } from '../services/upload-file.service';
import { UploadFileDetailViewService } from '../services/upload-file-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractUploadFileComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(UploadFileViewService);
  public readonly serviceDetail = inject(UploadFileDetailViewService);
  protected title = '::UploadFiles';

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

  update(record: UploadFileDto) {
    this.serviceDetail.update(record);
  }

  delete(record: UploadFileDto) {
    this.service.delete(record);
  }

  exportToExcel() {
    this.service.exportToExcel();
  }
}
