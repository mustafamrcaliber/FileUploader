import { inject, Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';
import { finalize, tap } from 'rxjs/operators';

import type { ModelTrainingDto } from '../../../proxy/model-trainings/models';
import { ModelTrainingService } from '../../../proxy/model-trainings/model-training.service';

export abstract class AbstractModelTrainingDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);
  public readonly proxyService = inject(ModelTrainingService);
  public readonly list = inject(ListService);

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  buildForm() {
    const {
      type,
      path,
      dataSource,
      databaseConnectionString,
      documentsDirectoryPath,
      mode,
      trainingLog,
    } = this.selected || {};

    this.form = this.fb.group({
      type: [type ?? null, []],
      path: [path ?? null, []],
      dataSource: [dataSource ?? null, []],
      databaseConnectionString: [databaseConnectionString ?? '--', []],
      documentsDirectoryPath: [documentsDirectoryPath ?? '--', []],
      mode: [mode ?? null, []],
      trainingLog: [trainingLog ?? null, []],
    });
  }

  showForm() {
    this.buildForm();
    this.isVisible = true;
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: ModelTrainingDto) {
    this.selected = record;
    this.showForm();
  }

  hideForm() {
    this.isVisible = false;
    this.form.reset();
  }

  submitForm() {
    if (this.form.invalid) return;

    this.isBusy = true;

    const request = this.createRequest().pipe(
      finalize(() => (this.isBusy = false)),
      tap(() => this.hideForm())
    );

    request.subscribe(this.list.get);
  }

  private createRequest() {
    if (this.selected) {
      return this.proxyService.update(this.selected.id, {
        ...this.form.value,
        concurrencyStamp: this.selected.concurrencyStamp,
      });
    }
    return this.proxyService.create(this.form.value);
  }

  changeVisible($event: boolean) {
    this.isVisible = $event;
  }
}
