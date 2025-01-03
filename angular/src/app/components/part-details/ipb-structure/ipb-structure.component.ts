import { Component, OnInit, signal } from '@angular/core';
import { TreeViewComponent } from '../../tree-view/tree-view.component';
import { CommonModule } from '@angular/common';
import { partColumns } from './parts';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute } from '@angular/router';
import { getIpbParts } from 'src/utility/getIpbParts';
import { IpbDetailViewService } from 'src/app/ipbs/ipb/services/ipb-detail.service';
import { IpbDetailModalComponent } from 'src/app/ipbs/ipb/components/ipb-detail.component';
import { IpbViewService } from 'src/app/ipbs/ipb/services/ipb.service';

@Component({
  selector: 'app-ipb-structure',
  standalone: true,
  imports: [
    TreeViewComponent,
    CommonModule,
    ThemeSharedModule,
    NgbNavModule,
    IpbDetailModalComponent,
  ],
  templateUrl: './ipb-structure.component.html',
  styleUrl: './ipb-structure.component.scss',
  providers: [IpbDetailViewService, IpbViewService],
})
export class IpbStructureComponent implements OnInit {
  public ipbs = signal<any[]>([]);
  public columns: { name: string; field: string }[] = partColumns;
  public isVisible = false;
  public partId: string = '';

  constructor(
    private readonly ipbService: IpbViewService,
    private readonly route: ActivatedRoute,
    public readonly ipbDetailViewService: IpbDetailViewService
  ) {
    this.route.params.subscribe(({ id }) => {
      this.partId = id;
    });
  }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    const data = this.ipbService.getIpbsForRelated(this.partId);
    data.subscribe(data => {
      const ipbsForThisPart = this.ipbService.getIpbsForSource(this.partId);
      ipbsForThisPart.subscribe(ipbData => {
        const ipb = getIpbParts(ipbData as any[]);
        this.ipbs.set([
          ...ipb,
          {
            ...data?.[0]?.ipb,
            ...data?.[0]?.related,
            id: data?.[0]?.ipb?.id,
            concurrencyStamp: data?.[0]?.ipb?.concurrencyStamp,
            relatedId: data?.[0]?.ipb?.relatedId,
            sourceId: data?.[0]?.ipb?.sourceId,
          },
        ]);
      });
    });
  }

  addHandler(event: any) {
    this.ipbDetailViewService.create({
      ipb: {
        ipbIndex: '',
        figureName: '',
        figureNumber: '',
        toNumber: '',
        indentureLevel: '',
        sourceId: this.partId,
        relatedId: undefined,
      },
    });
    this.loadData();
  }

  editHandler(event: any) {
    const ipb = event.dataItem;
    this.ipbDetailViewService.update({
      ipb: {
        ...ipb,
        concurrencyStamp: ipb.concurrencyStamp,
      },
    } as any);
  }

  submitHandler() {
    this.ipbDetailViewService.submitForm().subscribe(() => {
      this.loadData();
    });
  }

  removeHandler(event: any) {
    this.ipbService.delete({ ipb: event.dataItem } as any).subscribe(() => {
      this.loadData();
    });
  }

  closeModal() {
    this.isVisible = false;
  }
}
