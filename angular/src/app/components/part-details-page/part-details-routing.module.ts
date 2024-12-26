import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PartDetailsPageComponent } from './part-details-page.component';

const routes: Routes = [{ path: '', component: PartDetailsPageComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PartDetailsRoutingModule {}