import { PageModule } from '@abp/ng.components/page';
import {
  Component,
  computed,
  inject,
  Input,
  OnChanges,
  OnInit,
  Signal,
  SimpleChanges,
} from '@angular/core';
import { KENDO_CARD } from '@progress/kendo-angular-layout';
import { DefaultCardComponent } from '../components/default-card/default-card.component';
import { CommonModule } from '@angular/common';
import { PartService } from '@proxy/parts';
import { PartDetailModalComponent } from '../parts/part/components/part-detail.component';

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
      }));
    }
  }
}