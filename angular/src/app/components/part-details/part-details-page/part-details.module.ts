import { NgModule } from '@angular/core';
import { PartDetailsPageComponent } from './part-details-page.component';
import { PartDetailsRoutingModule } from './part-details-routing.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
  ],
  imports: [PartDetailsRoutingModule, PartDetailsPageComponent,PartDetailsPageComponent, ReactiveFormsModule],
})
export class PartDetailsModule {}
