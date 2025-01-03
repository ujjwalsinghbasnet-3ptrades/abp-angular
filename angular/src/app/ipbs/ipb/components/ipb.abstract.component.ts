import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import type { IpbWithNavigationPropertiesDto } from '../../../proxy/ipbs/models';
import { IpbViewService } from '../services/ipb.service';
import { IpbDetailViewService } from '../services/ipb-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractIpbComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(IpbViewService);
  public readonly serviceDetail = inject(IpbDetailViewService);
  protected title = '::Ipbs';

  ngOnInit() {
    this.service.hookToQuery();
  }

  clearFilters() {
    this.service.clearFilters();
  }

  showForm() {
    this.serviceDetail.showForm();
  }

  create() {
    this.serviceDetail.selected = undefined;
    this.serviceDetail.showForm();
  }

  update(record: IpbWithNavigationPropertiesDto) {
    this.serviceDetail.update(record);
  }

  delete(record: IpbWithNavigationPropertiesDto) {
    this.service.delete(record);
  }
}
