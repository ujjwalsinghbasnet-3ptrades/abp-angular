import { PageModule } from '@abp/ng.components/page';
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { KENDO_CARD } from '@progress/kendo-angular-layout';
import { CommonModule } from '@angular/common';
import { PartDto } from '@proxy/parts';
import { DefaultCardComponent } from '../default-card/default-card.component';
import { PartDetailModalComponent } from 'src/app/parts/part/components/part-detail.component';
import { PartDetailViewService } from 'src/app/parts/part/services/part-detail.service';
import { PartViewService } from 'src/app/parts/part/services/part.service';

@Component({
  selector: 'app-part-card-view',
  standalone: true,
  imports: [PageModule, KENDO_CARD, DefaultCardComponent, CommonModule, PartDetailModalComponent],
  templateUrl: './part-card-view.component.html',
  styleUrl: './part-card-view.component.scss',
})
export class PartCardViewComponent implements OnChanges {
  @Input() parts: any[] = [];
  cardParts: any[] = [];

  constructor(
    public partDetailService: PartDetailViewService,
    public partService: PartViewService
  ) {
    this.partDetailService = partDetailService;
    this.partService = partService;
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['parts'] && this.parts) {
      this.cardParts = this.parts.map(part => ({
        title: part.name,
        link: `/part/${part.id}`,
        imageUrl: part.imageUrl,
        iconClassName: 'fa fa-cogs fa-10x',
        cardBody: {
          partNumber: part.partNumber,
          cageCode: part.cageCode,
          smr: part.smr,
          niin: part.niin,
          toNumber: part.toNumber,
          fsc: part.fsc,
          wuc: part.wuc,
          uoc: part.uoc,
        },
        dataItem: part,
        cardActionProps: [
          {
            policy: 'AbpPoc.Parts.Edit',
            label: 'Edit',
            onClick: (part: PartDto) => {
              this.partDetailService.update(part);
            },
          },
          {
            policy: 'AbpPoc.Parts.Delete',
            label: 'Delete',
            onClick: (part: PartDto) => {
              this.partService.delete(part);
            },
          },
        ],
      }));
    }
  }
}
