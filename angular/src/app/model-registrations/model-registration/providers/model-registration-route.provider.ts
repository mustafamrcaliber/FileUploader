import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const MODEL_REGISTRATIONS_MODEL_REGISTRATION_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/model-registrations',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ModelRegistrations',
        layout: eLayoutType.application,
        requiredPolicy: 'FileUploader.ModelRegistrations',
      },
    ]);
  };
}
