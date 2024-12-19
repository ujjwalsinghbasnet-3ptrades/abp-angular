import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PartCardViewComponent } from './part-card-view.component';
import { authGuard, permissionGuard } from '@abp/ng.core';

export const routes: Routes = [
  {
    path: '',
    component: PartCardViewComponent,
    canActivate: [authGuard, permissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PartCardViewRoutingModule {}
