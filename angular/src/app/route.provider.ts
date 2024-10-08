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
        name: '::Menu:Issues',
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
      {
        path: '/',
        name: '::Menu:ApplicationSetUp',
        iconClass: 'fas fa-stream',
        order: 4,
        layout: eLayoutType.application,
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/',
        name: '::Menu:Charts',
        iconClass: 'fas fa-chart-pie',
        order: 5,
        layout: eLayoutType.application,
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/',
        name: '::Menu:Settings',
        iconClass: 'fas fa-cog',
        order: 5,
        layout: eLayoutType.application,
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      // {
      //   path: '/',
      //   name: '::Menu:DataCo-pilot',
      //   iconClass: 'fas fa-project-diagram',
      //   order: 5,
      //   layout: eLayoutType.application,
      //   requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      // },
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
        path: '/user-input',
        name: '::Menu:UserInput',
        iconClass: 'fas fa-comments',
        order: 1,
        layout: eLayoutType.application,
        parentName: '::Menu:FileViewMenu',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/data-visualization',
        name: '::Menu:DataVisualization',
        iconClass: 'fas fa-chart-pie',
        order: 2,
        layout: eLayoutType.application,
        parentName: '::Menu:FileViewMenu',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/auto-data-visualization',
        name: '::Menu:AutoDataVisualization',
        iconClass: 'fas fa-chart-pie',
        order: 3,
        layout: eLayoutType.application,
        parentName: '::Menu:FileViewMenu',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/',
        name: '::Menu:Models',
        iconClass: 'fas fa-cog',
        order: 4,
        layout: eLayoutType.application,
        parentName: '::Menu:ApplicationSetUp',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/',
        name: '::Menu:ModelTuners',
        iconClass: 'fas fa-cogs',
        order: 5,
        layout: eLayoutType.application,
        parentName: '::Menu:ApplicationSetUp',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/',
        name: '::Menu:Scheduler',
        iconClass: 'fas fa-calendar-check',
        order: 6,
        layout: eLayoutType.application,
        parentName: '::Menu:ApplicationSetUp',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/',
        name: '::Menu:DataPipeLines',
        iconClass: 'fas fa-wave-square',
        order: 1,
        layout: eLayoutType.application,
        parentName: '::Menu:ApplicationSetUp',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      // {
      //   path: '/',
      //   name: '::Menu:Kanban',
      //   iconClass: 'fas fa-clipboard-list',
      //   order:5,
      //   layout: eLayoutType.application,
      // },
      // // {
      // //   path: '/',
      // //   name: '::Menu:Issues',
      // //   iconClass: 'fas fa-bars',
      // //   order:6,
      // //   layout: eLayoutType.application,
      // // },
      // {
      //   path: '/',
      //   name: '::Menu:Procedures',
      //   iconClass: 'fas fa-route',
      //   order:7,
      //   layout: eLayoutType.application,
      // },
      // {
      //   path: '/',
      //   name: '::Menu:skills',
      //   iconClass: 'fas fa-book',
      //   order:8,
      //   layout: eLayoutType.application,
      // },
      // // {
      // //   path: '/',
      // //   name: '::Menu:Files',
      // //   iconClass: 'fas fa-bars',
      // //   order:9,
      // //   layout: eLayoutType.application,
      // // },
      // // {
      // //   path: '/',
      // //   name: '::Menu:Posts',
      // //   iconClass: 'fas fa-bars',
      // //   order:10,
      // //   layout: eLayoutType.application,
      // // },
      // {
      //   path: '/',
      //   name: '::Menu:Schedule',
      //   iconClass: 'fas fa-calendar-alt',
      //   order:11,
      //   layout: eLayoutType.application,
      // },
      // {
      //   path: '/',
      //   name: '::Menu:History',
      //   iconClass: 'fas fa-history',
      //   order:12,
      //   layout: eLayoutType.application,
      // },
      // {
      //   path: '/',
      //   name: '::Menu:About',
      //   iconClass: 'fas fa-info-circle',
      //   order:13,
      //   layout: eLayoutType.application,
      // }
      {
        path: '/model-configurations',
        name: '::ModelConfigurations',
        iconClass: '',
        order: 1,
        layout: eLayoutType.application,
        parentName: '::Menu:Settings',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/model-registrations',
        name: '::ModelRegistrations',
        iconClass: '',
        order: 1,
        layout: eLayoutType.application,
        parentName: '::Menu:Settings',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/model-trainings',
        name: '::ModelTrainings',
        iconClass: '',
        order: 1,
        layout: eLayoutType.application,
        parentName: '::Menu:Settings',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
      {
        path: '/chart-one',
        name: '::ChartOne',
        iconClass: '',
        order: 1,
        layout: eLayoutType.application,
        parentName: '::Menu:Charts',
        requiredPolicy: 'FileUploader.Dashboard.Host  || FileUploader.Dashboard.Tenant',
      },
    ]);
  };
}
