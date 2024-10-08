import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <app-host-dashboard *abpPermission="'FileUploader.Dashboard.Host'"></app-host-dashboard>
    <app-tenant-dashboard *abpPermission="'FileUploader.Dashboard.Tenant'"></app-tenant-dashboard>
  `,
})
export class DashboardComponent {}
