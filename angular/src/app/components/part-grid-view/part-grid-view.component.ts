import { PageModule } from '@abp/ng.components/page';
import { CoreModule, ListService } from '@abp/ng.core';
import { Component, inject } from '@angular/core';
import { PartViewService } from 'src/app/parts/part/services/part.service';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { AbstractPartDetailViewService } from 'src/app/parts/part/services/part-detail.abstract.service';
import { PartDetailViewService } from 'src/app/parts/part/services/part-detail.service';
@Component({
  selector: 'app-part-grid-view',
  standalone: true,
  imports: [PageModule, CoreModule,CommercialUiModule, ThemeSharedModule],
  templateUrl: './part-grid-view.component.html',
  styleUrl: './part-grid-view.component.scss',
  providers: [
    ListService,
    PartViewService,
    PartDetailViewService,
    {
      provide: AbstractPartDetailViewService,
      useClass: PartDetailViewService,
    },
  ],
})
export class PartGridViewComponent {
  public readonly list = inject(PartViewService);
  constructor(public service: PartViewService) {
    this.service = service;
  }
}
