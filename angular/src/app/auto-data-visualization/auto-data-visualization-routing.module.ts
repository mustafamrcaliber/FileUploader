import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutoDataVisualizationComponent } from './auto-data-visualization.component';

export const routes: Routes = [
  {
    path: '',
    component: AutoDataVisualizationComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AutoDataVisualizationRoutingModule {}
