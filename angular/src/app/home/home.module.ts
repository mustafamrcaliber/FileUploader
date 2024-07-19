import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { NgApexchartsModule } from 'ng-apexcharts';
import { ChatScreenModule } from '../chat-screen/chat-screen.module';
import { ChatScreenComponent } from '../chat-screen/chat-screen.component';

@NgModule({
  declarations: [HomeComponent],
  imports: [SharedModule, HomeRoutingModule, PageModule,
    NgbModule,
    CommonModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    NgxValidateCoreModule,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbDropdownModule,
    NgbOffcanvasModule,
    NgbAccordionModule,
    // BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    NgxChartsModule,
    NgApexchartsModule,
    ChatScreenModule
  ],
})
export class HomeModule {}
