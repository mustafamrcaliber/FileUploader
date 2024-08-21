import { inject, Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';
import { finalize, tap } from 'rxjs/operators';

import type { ModelConfigurationDto } from '../../../proxy/model-configurations/models';
import { ModelConfigurationService } from '../../../proxy/model-configurations/model-configuration.service';

export abstract class AbstractModelConfigurationDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);
  public readonly proxyService = inject(ModelConfigurationService);
  public readonly list = inject(ListService);

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  buildForm() {
    const { systemPrompt, temperature, topK, topP, repeatPenalty, contextLength, maxTokens } =
      this.selected || {};

    this.form = this.fb.group({
      systemPrompt: [systemPrompt ?? null, []],
      temperature: [temperature ?? null, []],
      topK: [topK ?? null, []],
      topP: [topP ?? null, []],
      repeatPenalty: [repeatPenalty ?? null, []],
      contextLength: [contextLength ?? null, []],
      maxTokens: [maxTokens ?? null, []],
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

  update(record: ModelConfigurationDto) {
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
