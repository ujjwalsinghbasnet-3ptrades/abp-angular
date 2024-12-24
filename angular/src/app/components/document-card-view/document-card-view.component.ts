import { PermissionService } from '@abp/ng.core';
import { CommonModule } from '@angular/common';
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { DocumentDto } from '@proxy/documents';
import { DocumentDetailViewService } from 'src/app/documents/document/services/document-detail.service';
import { DocumentViewService } from 'src/app/documents/document/services/document.service';
import { DefaultCardComponent } from '../default-card/default-card.component';

@Component({
  selector: 'app-document-card-view',
  standalone: true,
  imports: [CommonModule, DefaultCardComponent],
  templateUrl: './document-card-view.component.html',
  styleUrl: './document-card-view.component.scss',
})
export class DocumentCardViewComponent implements OnChanges {
  @Input() documents: DocumentDto[] = [];
  cardDocuments: any[] = [];
  constructor(
    protected documentDetailService: DocumentDetailViewService,
    protected documentService: DocumentViewService,
    protected documentPermissionService: PermissionService
  ) {
    this.documentDetailService = documentDetailService;
    this.documentPermissionService = documentPermissionService;
    this.documentService = documentService;
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['documents'] && this.documents) {
      this.cardDocuments = this.documents.map(document => ({
        title: document.name,
        link: `/document/${document.id}`,
        iconClassName: 'fa fa-file-pdf fa-10x',
        cardBody: {
          documentSize: document.size,
          documentType: document.type,
        },
        dataItem: document,
        cardActionProps: [
          {
            show: this.documentPermissionService.getGrantedPolicy('AbpPoc.Documents.Edit'),
            label: 'Edit',
            onClick: (document: DocumentDto) => {
              this.documentDetailService.update(document);
            },
          },
          {
            show: this.documentPermissionService.getGrantedPolicy('AbpPoc.Documents.Delete'),
            label: 'Delete',
            onClick: (document: DocumentDto) => {
              this.documentService.delete(document);
            },
          },
        ],
      }));
    }
  }
}
