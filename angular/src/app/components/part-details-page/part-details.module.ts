import { NgModule } from '@angular/core';
import { PageModule } from '@abp/ng.components/page';
import { PartDetailsPageComponent } from './part-details-page.component';
import { PartDetailsRoutingModule } from './part-details-routing.module';

@NgModule({
  declarations: [],
  imports: [PartDetailsRoutingModule, PartDetailsPageComponent,PartDetailsPageComponent],
})
export class PartDetailsModule {}
