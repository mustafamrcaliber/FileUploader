import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter } from '@abp/ng.theme.shared';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbDateAdapter, NgbDatepickerModule, NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { ModelTrainingDetailViewService } from '../services/model-training-detail.service';

@Component({
  selector: 'app-model-training-detail-modal',
  changeDetection: ChangeDetectionStrategy.Default,
  standalone: true,
  imports: [
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    ReactiveFormsModule,
    NgbDatepickerModule,
    NgbNavModule,
  ],
  providers: [{ provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './model-training-detail.component.html',
  styles: [],
})
export class ModelTrainingDetailModalComponent {
  modes: {name: string, value: number }[] = [
{value: 1, name: "Text"},
{value: 2, name: "Chart"},
{value: 3, name: "Image"}
  ];
  public readonly service = inject(ModelTrainingDetailViewService);
}
