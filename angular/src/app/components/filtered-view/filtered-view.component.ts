import { PageModule } from '@abp/ng.components/page';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-filtered-view',
  standalone: true,
  imports: [PageModule],
  templateUrl: './filtered-view.component.html',
  styleUrl: './filtered-view.component.scss'
})
export class FilteredViewComponent {
  @Input() title: string = '';
}
