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

import { ModelRegistrationViewService } from '../services/model-registration.service';
import { ModelRegistrationDetailViewService } from '../services/model-registration-detail.service';
import { ModelRegistrationDetailModalComponent } from './model-registration-detail.component';
import {
  AbstractModelRegistrationComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './model-registration.abstract.component';

@Component({
  selector: 'app-model-registration',
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
    ModelRegistrationDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    ModelRegistrationViewService,
    ModelRegistrationDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
  ],
  templateUrl: './model-registration.component.html',
  styles: `::ng-deep.datatable-row-detail { background: transparent !important; }`,
})
export class ModelRegistrationComponent extends AbstractModelRegistrationComponent {}
