import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PartDetailsPageComponent } from './part-details-page.component';

const routes: Routes = [
  {
    path: '',
    component: PartDetailsPageComponent,
    data: {
      breadcrumb: {
        title: 'Part Details',
        routes: [
          {
            text: 'Home',
            path: '/',
          },
          {
            text: 'Parts',
            path: '/parts',
          },
          {
            text: 'Part Details',
          },
        ],
      },
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  declarations: [],
})
export class PartDetailsRoutingModule {}
