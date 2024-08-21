import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ModelRegistrationComponent } from './components/model-registration.component';

export const routes: Routes = [
  {
    path: '',
    component: ModelRegistrationComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ModelRegistrationRoutingModule {}
