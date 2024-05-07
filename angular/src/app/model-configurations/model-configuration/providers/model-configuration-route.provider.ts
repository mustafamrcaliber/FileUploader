import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const MODEL_CONFIGURATIONS_MODEL_CONFIGURATION_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/model-configurations',
        iconClass: 'fas fa-gear',
        name: '::Menu:ModelConfigurations',
        layout: eLayoutType.application,
        requiredPolicy: 'FileUploader.ModelConfigurations',
      },
    ]);
  };
}
