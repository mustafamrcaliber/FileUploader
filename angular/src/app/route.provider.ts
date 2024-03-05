import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/dashboard',
        name: '::Menu:Dashboard',
        iconClass: 'fas fa-chart-line',
        order: 2,
        layout: eLayoutType.application,
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/',
        name: '::Menu:FileViewMenu',
        iconClass: 'fas fa-file',
        order: 3,
        layout: eLayoutType.application,
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      // {
      //   path: '/file-view-masters',
      //   name: '::Menu:FileViewMasters',
      //   iconClass: 'fas fa-file',
      //   order: 2,
      //   layout: eLayoutType.application,
      //   parentName: '::Menu:FileViewMenu',
      //   requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      // },
      {
        path: '/upload-files',
        name: '::Menu:FileUpload',
        iconClass: 'fas fa-file-upload',
        order: 1,
        layout: eLayoutType.application,
        parentName: '::Menu:FileViewMenu',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/chat-screen',
        name: '::Menu:ChatScreen',
        iconClass: 'fas fa-comments',
        order: 1,
        layout: eLayoutType.application,
        parentName: '::Menu:FileViewMenu',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/',
        name: '::Menu:Kanban',
        iconClass: 'fas fa-bars',
        order:4,
        layout: eLayoutType.application,
      },
      {
        path: '/',
        name: '::Menu:Issues',
        iconClass: 'fas fa-bars',
        order:4,
        layout: eLayoutType.application,
      },
      {
        path: '/',
        name: '::Menu:Procedures',
        iconClass: 'fas fa-bars',
        order:4,
        layout: eLayoutType.application,
      },
      {
        path: '/',
        name: '::Menu:skills',
        iconClass: 'fas fa-bars',
        order:4,
        layout: eLayoutType.application,
      },
      {
        path: '/',
        name: '::Menu:Files',
        iconClass: 'fas fa-bars',
        order:4,
        layout: eLayoutType.application,
      },
      {
        path: '/',
        name: '::Menu:Posts',
        iconClass: 'fas fa-bars',
        order:4,
        layout: eLayoutType.application,
      },
      {
        path: '/',
        name: '::Menu:Schedule',
        iconClass: 'fas fa-bars',
        order:4,
        layout: eLayoutType.application,
      },
      {
        path: '/',
        name: '::Menu:History',
        iconClass: 'fas fa-bars',
        order:4,
        layout: eLayoutType.application,
      },
      {
        path: '/',
        name: '::Menu:About',
        iconClass: 'fas fa-bars',
        order:4,
        layout: eLayoutType.application,
      }
    ]);
  };
}
