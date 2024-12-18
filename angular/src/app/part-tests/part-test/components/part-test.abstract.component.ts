import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import type { PartTestDto } from '../../../proxy/part-tests/models';
import { PartTestViewService } from '../services/part-test.service';
import { PartTestDetailViewService } from '../services/part-test-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractPartTestComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(PartTestViewService);
  public readonly serviceDetail = inject(PartTestDetailViewService);
  protected title = '::PartTests';

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

  update(record: PartTestDto) {
    this.serviceDetail.update(record);
  }

  delete(record: PartTestDto) {
    this.service.delete(record);
  }

  exportToExcel() {
    this.service.exportToExcel();
  }
}
