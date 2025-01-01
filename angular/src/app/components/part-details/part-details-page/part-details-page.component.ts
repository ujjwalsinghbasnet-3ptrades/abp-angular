import { PageModule } from '@abp/ng.components/page';
import { ListService } from '@abp/ng.core';
import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { PartDetailViewService } from 'src/app/parts/part/services/part-detail.service';
import { PartViewService } from 'src/app/parts/part/services/part.service';
import { OverviewComponent } from '../overview/overview.component';
import { IpbStructureComponent } from '../ipb-structure/ipb-structure.component';

@Component({
  selector: 'app-part-details-page',
  standalone: true,
  imports: [PageModule, CommonModule, OverviewComponent, IpbStructureComponent],
  templateUrl: './part-details-page.component.html',
  styleUrls: ['./part-details-page.component.scss'],
  providers: [ListService, PartDetailViewService, PartViewService],
})
export class PartDetailsPageComponent {
  public selectedTab = signal<string>('overview');

  handleTabChange(tab: string) {
    this.selectedTab.set(tab);
  }
}
