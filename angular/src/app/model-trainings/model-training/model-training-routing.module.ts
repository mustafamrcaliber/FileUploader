import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ModelTrainingComponent } from './components/model-training.component';

export const routes: Routes = [
  {
    path: '',
    component: ModelTrainingComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ModelTrainingRoutingModule {}
