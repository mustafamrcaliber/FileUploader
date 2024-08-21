import { NgModule } from '@angular/core';
import { AutoDataVisualizationComponent } from './auto-data-visualization.component';
import { AutoDataVisualizationRoutingModule } from './auto-data-visualization-routing.module';
import {
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbDropdownModule,
  NgbOffcanvasModule,
  NgbAccordionModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxChartsModule } from '@swimlane/ngx-charts';

@NgModule({
  declarations: [AutoDataVisualizationComponent],
  imports: [
    AutoDataVisualizationRoutingModule,
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
    NgbAccordionModule,
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    NgxChartsModule
  ],
  exports: [AutoDataVisualizationRoutingModule],
})
export class AutoDataVisualizationModule {}
