import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule),
    canActivate: [authGuard, permissionGuard],
  },
  {
    path: 'account',
    loadChildren: () =>
      import('@volo/abp.ng.account/public').then(m => m.AccountPublicModule.forLazy()),
  },
  {
    path: 'gdpr',
    loadChildren: () => import('@volo/abp.ng.gdpr').then(m => m.GdprModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@volo/abp.ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'language-management',
    loadChildren: () =>
      import('@volo/abp.ng.language-management').then(m => m.LanguageManagementModule.forLazy()),
  },
  {
    path: 'saas',
    loadChildren: () => import('@volo/abp.ng.saas').then(m => m.SaasModule.forLazy()),
  },
  {
    path: 'audit-logs',
    loadChildren: () =>
      import('@volo/abp.ng.audit-logging').then(m => m.AuditLoggingModule.forLazy()),
  },
  {
    path: 'openiddict',
    loadChildren: () =>
      import('@volo/abp.ng.openiddictpro').then(m => m.OpeniddictproModule.forLazy()),
  },
  {
    path: 'text-template-management',
    loadChildren: () =>
      import('@volo/abp.ng.text-template-management').then(m =>
        m.TextTemplateManagementModule.forLazy()
      ),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  {
    path: 'gdpr-cookie-consent',
    loadChildren: () =>
      import('./gdpr-cookie-consent/gdpr-cookie-consent.module').then(
        m => m.GdprCookieConsentModule
      ),
  },
  {
    path: 'upload-files',
    loadChildren: () =>
      import('./upload-files/upload-file/upload-file.module').then(m => m.UploadFileModule),
  },
  {
    path: 'file-view-masters',
    loadChildren: () =>
      import('./file-view-masters/file-view-masters.module').then(m => m.FileViewMastersModule),
  },
  {
    path: 'chat-screen',
    loadChildren: () =>
      import('./chat-screen/chat-screen-routing.module').then(m => m.ChatScreenRoutingModule),
  },
  {
    path: 'chart-one',
    loadChildren: () =>
      import('./chart-one/chart-one-routing.module').then(m => m.ChartOneRoutingModule),
  },
  {
    path: 'data-visualization',
    loadChildren: () =>
      import('./data-visualization/data-visualization-routing.module').then(
        m => m.DataVisualizationRoutingModule
      ),
  },
  {
    path: 'auto-data-visualization',
    loadChildren: () =>
      import('./auto-data-visualization/auto-data-visualization-routing.module').then(
        m => m.AutoDataVisualizationRoutingModule
      ),
  },
  {
    path: 'model-configurations',
    loadChildren: () =>
      import('./model-configurations/model-configuration/model-configuration.module').then(
        m => m.ModelConfigurationModule
      ),
  },
  {
    path: 'model-registrations',
    loadChildren: () =>
      import('./model-registrations/model-registration/model-registration.module').then(
        m => m.ModelRegistrationModule
      ),
  },
  {
    path: 'model-trainings',
    loadChildren: () =>
      import('./model-trainings/model-training/model-training.module').then(
        m => m.ModelTrainingModule
      ),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
