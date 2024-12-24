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

import { PartViewService } from '../services/part.service';
import { PartDetailViewService } from '../services/part-detail.service';
import { PartDetailModalComponent } from './part-detail.component';
import {
  AbstractPartComponent,
  ChildTabDependencies,
  ChildComponentDependencies,
} from './part.abstract.component';
import { AbstractPartDetailViewService } from '../services/part-detail.abstract.service';
import { PartCardViewComponent } from 'src/app/components/part-card-view/part-card-view.component';
import { PartGridViewComponent } from 'src/app/components/part-grid-view/part-grid-view.component';
import { AdvancedFiltersComponent } from 'src/app/common/advanced-filters/advanced-filters.component';
import { FilteredViewComponent } from 'src/app/components/filtered-view/filtered-view.component';

@Component({
  selector: 'app-part',
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
    PartDetailModalComponent,
    PartCardViewComponent,
    PartGridViewComponent,
    AdvancedFiltersComponent,
    FilteredViewComponent,
    ...ChildComponentDependencies,
  ],
  providers: [
    ListService,
    PartViewService,
    PartDetailViewService,
    {
      provide: AbstractPartDetailViewService,
      useClass: PartDetailViewService,
    },
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './part.component.html',
  styles: `
    ::ng-deep.datatable-row-detail {
      background: transparent !important;
    }
  `,
})
export class PartComponent extends AbstractPartComponent {
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
