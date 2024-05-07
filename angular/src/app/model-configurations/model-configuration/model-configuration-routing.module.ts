import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ModelConfigurationComponent } from './components/model-configuration.component';

export const routes: Routes = [
  {
    path: '',
    component: ModelConfigurationComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ModelConfigurationRoutingModule {}
