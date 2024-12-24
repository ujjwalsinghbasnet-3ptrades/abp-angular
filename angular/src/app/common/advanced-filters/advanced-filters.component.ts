import { PageModule } from '@abp/ng.components/page';
import { CoreModule, ListService } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

@Component({
  selector: 'app-advanced-filters',
  standalone: true,
  imports: [CommercialUiModule, CommonModule, CoreModule, ThemeSharedModule],
  templateUrl: './advanced-filters.component.html',
  styleUrl: './advanced-filters.component.scss',
  providers: [
    ListService,
  ],
})
export class AdvancedFiltersComponent {
  @Input() filters: any = {};
  @Input() filterConfig: { label: string; key: string; type?: string }[] = [];
  @Output() filtersChanged = new EventEmitter<any>();
  @Output() refresh = new EventEmitter<void>();
  @Output() clear = new EventEmitter<void>();
  @Input() list: ListService;

  onFilterChange() {
    this.filtersChanged.emit(this.filters);
  }

  clearFilters() {
    this.filters = {};
    this.clear.emit();
  }

  refreshList() {
    this.refresh.emit();
  }
}
