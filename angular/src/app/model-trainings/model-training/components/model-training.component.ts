import { ChangeDetectionStrategy, Component } from '@angular/core';
import {
  NgbDateAdapter,
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { ListService, CoreModule } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter } from '@abp/ng.theme.shared';
import { PageModule } from '@abp/ng.components/page';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

import { ModelTrainingViewService } from '../services/model-training.service';
import { ModelTrainingDetailViewService } from '../services/model-training-detail.service';
import { ModelTrainingDetailModalComponent } from './model-training-detail.component';
import {
  AbstractModelTrainingComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './model-training.abstract.component';

@Component({
  selector: 'app-model-training',
  changeDetection: ChangeDetectionStrategy.Default,
  standalone: true,
  imports: [
    ...ChildTabDependencies,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbDropdownModule,

    NgxValidateCoreModule,

    PageModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    ModelTrainingDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    ModelTrainingViewService,
    ModelTrainingDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
  ],
  templateUrl: './model-training.component.html',
  styles: `::ng-deep.datatable-row-detail { background: transparent !important; }`,
})
export class ModelTrainingComponent extends AbstractModelTrainingComponent {}
