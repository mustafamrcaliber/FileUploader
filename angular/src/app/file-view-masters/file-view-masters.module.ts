import { NgModule } from '@angular/core';
import { FileViewMastersComponent  } from './file-view-masters.component';
import { FileViewMastersRoutingModule } from './file-view-masters-routing.module';
import {
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbDropdownModule,
  NgbOffcanvasModule,
  NgbAccordionModule
} from '@ng-bootstrap/ng-bootstrap';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';

@NgModule({
  declarations: [FileViewMastersComponent],
  imports: [FileViewMastersRoutingModule,
    NgbModule,
    CommonModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    NgxValidateCoreModule,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbDropdownModule,
    PageModule,
    NgbOffcanvasModule,
    NgbAccordionModule],
    exports:[FileViewMastersComponent]
})
export class FileViewMastersModule {}
