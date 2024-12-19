import { NgModule } from '@angular/core';
import { PartCardViewComponent } from './part-card-view.component';
import { PartCardViewRoutingModule } from './part-card-routing.module';
import { PartDetailModalComponent } from '../parts/part/components/part-detail.component';

@NgModule({
  declarations: [],
  imports: [PartCardViewComponent, PartCardViewRoutingModule, PartDetailModalComponent],
})
export class PartCardViewModule {}
