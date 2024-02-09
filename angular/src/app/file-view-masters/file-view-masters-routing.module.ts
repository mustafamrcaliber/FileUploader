import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FileViewMastersComponent } from './file-view-masters.component';

export const routes: Routes = [
  {
    path: '',
    component: FileViewMastersComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FileViewMastersRoutingModule {}
