import { CoreModule } from '@abp/ng.core';
import { GdprConfigModule } from '@volo/abp.ng.gdpr/config';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommercialUiConfigModule } from '@volo/abp.commercial.ng.ui/config';
import { AccountAdminConfigModule } from '@volo/abp.ng.account/admin/config';
import { AccountPublicConfigModule } from '@volo/abp.ng.account/public/config';
import { AuditLoggingConfigModule } from '@volo/abp.ng.audit-logging/config';
import { IdentityConfigModule } from '@volo/abp.ng.identity/config';
import { LanguageManagementConfigModule } from '@volo/abp.ng.language-management/config';
import { registerLocale } from '@volo/abp.ng.language-management/locale';
import { SaasConfigModule } from '@volo/abp.ng.saas/config';
import { TextTemplateManagementConfigModule } from '@volo/abp.ng.text-template-management/config';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { OpeniddictproConfigModule } from '@volo/abp.ng.openiddictpro/config';
import { FeatureManagementModule } from '@abp/ng.feature-management';
import { AbpOAuthModule } from '@abp/ng.oauth';
import { ThemeLeptonXModule } from '@volosoft/abp.ng.theme.lepton-x';
import { SideMenuLayoutModule } from '@volosoft/abp.ng.theme.lepton-x/layouts';
import { FileViewMastersComponent } from './file-view-masters/file-view-masters.component';
import { FileViewMastersModule } from './file-view-masters/file-view-masters.module';
import { ChatScreenModule } from './chat-screen/chat-screen.module';
import { UserInputModule } from './user-input/user-input.module';
import { DataVisualizationModule } from './data-visualization/data-visualization.module';
import { AutoDataVisualizationModule } from './auto-data-visualization/auto-data-visualization.module';
import { ChartOneModule } from './chart-one/chart-one.module';
// import { MODEL_CONFIGURATIONS_MODEL_CONFIGURATION_ROUTE_PROVIDER } from './model-configurations/model-configuration/providers/model-configuration-route.provider';
// import { MODEL_REGISTRATIONS_MODEL_REGISTRATION_ROUTE_PROVIDER } from './model-registrations/model-registration/providers/model-registration-route.provider';
// import { MODEL_TRAININGS_MODEL_TRAINING_ROUTE_PROVIDER } from './model-trainings/model-training/providers/model-training-route.provider';
// import { UPLOAD_FILES_UPLOAD_FILE_ROUTE_PROVIDER } from './upload-files/upload-file/providers/upload-file-route.provider';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
    }),
    AbpOAuthModule.forRoot(),
    ThemeSharedModule.forRoot(),
    AccountAdminConfigModule.forRoot(),
    AccountPublicConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    LanguageManagementConfigModule.forRoot(),
    SaasConfigModule.forRoot(),
    AuditLoggingConfigModule.forRoot(),
    OpeniddictproConfigModule.forRoot(),
    TextTemplateManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),

    CommercialUiConfigModule.forRoot(),
    FeatureManagementModule.forRoot(),
    GdprConfigModule.forRoot({
      privacyPolicyUrl: 'gdpr-cookie-consent/privacy',
      cookiePolicyUrl: 'gdpr-cookie-consent/cookie',
    }),
    ThemeLeptonXModule.forRoot(),
    SideMenuLayoutModule.forRoot(),
    FileViewMastersModule,
    ChatScreenModule,
    DataVisualizationModule,
    AutoDataVisualizationModule,
    ChartOneModule,
    UserInputModule
  ],
  providers: [
    APP_ROUTE_PROVIDER,
    // MODEL_CONFIGURATIONS_MODEL_CONFIGURATION_ROUTE_PROVIDER,
    // MODEL_REGISTRATIONS_MODEL_REGISTRATION_ROUTE_PROVIDER,
    // MODEL_TRAININGS_MODEL_TRAINING_ROUTE_PROVIDER,
    // UPLOAD_FILES_UPLOAD_FILE_ROUTE_PROVIDER
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
