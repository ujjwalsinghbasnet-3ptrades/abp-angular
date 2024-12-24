import { ChangeDetectionStrategy, Component } from '@angular/core';
import {
  NgbDateAdapter,
  NgbTimeAdapter,
  NgbCollapseModule,
  NgbDatepickerModule,
  NgbTimepickerModule,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { ListService, CoreModule } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter, TimeAdapter } from '@abp/ng.theme.shared';
import { PageModule } from '@abp/ng.components/page';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

import { DocumentViewService } from '../services/document.service';
import { DocumentDetailViewService } from '../services/document-detail.service';
import { DocumentDetailModalComponent } from './document-detail.component';
import {
  AbstractDocumentComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './document.abstract.component';
import { FilteredViewComponent } from 'src/app/components/filtered-view/filtered-view.component';
import { AdvancedFiltersComponent } from 'src/app/common/advanced-filters/advanced-filters.component';
import { DocumentCardViewComponent } from 'src/app/components/document-card-view/document-card-view.component';

@Component({
  selector: 'app-document',
  changeDetection: ChangeDetectionStrategy.Default,
  standalone: true,
  imports: [
    ...ChildTabDependencies,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbTimepickerModule,
    NgbDropdownModule,

    NgxValidateCoreModule,

    PageModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    DocumentDetailModalComponent,
    FilteredViewComponent,
    AdvancedFiltersComponent,
    DocumentCardViewComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    DocumentViewService,
    DocumentDetailViewService,
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './document.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class DocumentComponent extends AbstractDocumentComponent {
  selectedView: 'grid' | 'card' = 'grid';

  onViewChange(view: 'grid' | 'card') {
    this.selectedView = view;
  }

  onFiltersChanged(updatedFilters: any) {
    this.service.filters = updatedFilters;
  }

  clearFilters() {
    this.service.filters = { maxResultCount: 100 };
    this.list.get();
  }
}
