import { PageModule } from '@abp/ng.components/page';
import { Component } from '@angular/core';
import { KENDO_CARD } from '@progress/kendo-angular-layout';

@Component({
  selector: 'app-part-card-view',
  standalone: true,
  imports: [PageModule, KENDO_CARD],
  templateUrl: './part-card-view.component.html',
  styleUrl: './part-card-view.component.scss'
})
export class PartCardViewComponent {

}
