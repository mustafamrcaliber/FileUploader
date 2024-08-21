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

import { ModelConfigurationViewService } from '../services/model-configuration.service';
import { ModelConfigurationDetailViewService } from '../services/model-configuration-detail.service';
import { ModelConfigurationDetailModalComponent } from './model-configuration-detail.component';
import {
  AbstractModelConfigurationComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './model-configuration.abstract.component';

@Component({
  selector: 'app-model-configuration',
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
    ModelConfigurationDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    ModelConfigurationViewService,
    ModelConfigurationDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
  ],
  templateUrl: './model-configuration.component.html',
  styles: `::ng-deep.datatable-row-detail { background: transparent !important; }`,
})
export class ModelConfigurationComponent extends AbstractModelConfigurationComponent {}
