import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <app-host-dashboard *abpPermission="'AbpPoc.Dashboard.Host'"></app-host-dashboard>
    <app-tenant-dashboard *abpPermission="'AbpPoc.Dashboard.Tenant'"></app-tenant-dashboard>
  `,
})
export class DashboardComponent {}
