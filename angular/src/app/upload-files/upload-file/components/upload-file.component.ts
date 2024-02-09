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

import { UploadFileViewService } from '../services/upload-file.service';
import { UploadFileDetailViewService } from '../services/upload-file-detail.service';
import { UploadFileDetailModalComponent } from './upload-file-detail.component';
import {
  AbstractUploadFileComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './upload-file.abstract.component';

@Component({
  selector: 'app-upload-file',
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
    UploadFileDetailModalComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    UploadFileViewService,
    UploadFileDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
  ],
  templateUrl: './upload-file.component.html',
  styles: `::ng-deep.datatable-row-detail { background: transparent !important; }`,
})
export class UploadFileComponent extends AbstractUploadFileComponent {}
