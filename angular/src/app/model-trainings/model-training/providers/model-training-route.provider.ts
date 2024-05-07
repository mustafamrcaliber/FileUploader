import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const MODEL_TRAININGS_MODEL_TRAINING_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/model-trainings',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:ModelTrainings',
        layout: eLayoutType.application,
        requiredPolicy: 'FileUploader.ModelTrainings',
      },
    ]);
  };
}
