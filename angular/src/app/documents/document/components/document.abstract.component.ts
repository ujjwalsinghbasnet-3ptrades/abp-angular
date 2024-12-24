import { Directive, OnInit, inject } from '@angular/core';

import { ListService, TrackByService } from '@abp/ng.core';

import type { DocumentDto } from '../../../proxy/documents/models';
import { DocumentViewService } from '../services/document.service';
import { DocumentDetailViewService } from '../services/document-detail.service';

export const ChildTabDependencies = [];

export const ChildComponentDependencies = [];

@Directive({ standalone: true })
export abstract class AbstractDocumentComponent implements OnInit {
  public readonly list = inject(ListService);
  public readonly track = inject(TrackByService);
  public readonly service = inject(DocumentViewService);
  public readonly serviceDetail = inject(DocumentDetailViewService);
  protected title = '::Documents';

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

  update(record: DocumentDto) {
    this.serviceDetail.update(record);
  }

  delete(record: DocumentDto) {
    this.service.delete(record);
  }

  exportToExcel() {
    this.service.exportToExcel();
  }
}
