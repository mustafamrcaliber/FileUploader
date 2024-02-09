import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const UPLOAD_FILES_UPLOAD_FILE_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/upload-files',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:UploadFiles',
        layout: eLayoutType.application,
        requiredPolicy: 'FileUploader.UploadFiles',
      },
    ]);
  };
}
