import { PageModule } from '@abp/ng.components/page';
import { Component, inject, Input, OnInit } from '@angular/core';
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
export class PartCardViewComponent implements OnInit {
  parts: any[] = [];

  constructor(private partService: PartService) {}

  ngOnInit() {
    this.partService.getList({ maxResultCount: 10 }).subscribe(parts => {
      this.parts = parts.items.map(part => ({
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
    });
  }

  create() {
    this.partService
      .create({
        name: 'New Part',
        partNumber: '123456',
        cageCode: '123456',
        toNumber: '123456',
        nsn: '123456',
      })
      .subscribe(() => {
        this.parts = [
          ...this.parts,
          {
            title: 'New Part',
            imageUrl: null,
            iconClassName: 'fa fa-cogs fa-10x',
            cardBody: {},
          },
        ];
      });
  }
}
