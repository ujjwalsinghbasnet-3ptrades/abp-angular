import { inject, computed, signal } from '@angular/core';
import { SelectionType } from '@swimlane/ngx-datatable';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { ABP, AbpWindowService, ListService, PagedResultDto } from '@abp/ng.core';
import { filter, switchMap, finalize } from 'rxjs/operators';
import type { GetPartTestsInput, PartTestDto } from '../../../proxy/part-tests/models';
import { PartTestService } from '../../../proxy/part-tests/part-test.service';

export abstract class AbstractPartTestViewService {
  protected readonly proxyService = inject(PartTestService);
  protected readonly confirmationService = inject(ConfirmationService);
  protected readonly list = inject(ListService);
  protected readonly abpWindowService = inject(AbpWindowService);

  isExportToExcelBusy = false;

  data: PagedResultDto<PartTestDto> = {
    items: [],
    totalCount: 0,
  };

  selectionType = SelectionType;
  selected = signal<PartTestDto[]>([]);
  allSelected = signal(false);
  selectedCount = computed(() => this.selected().length);

  filters = {} as GetPartTestsInput;

  protected clearAllSelection() {
    this.selected.set([]);
    this.allSelected.set(false);
  }

  protected bulkDeleteRequest() {
    const ids = this.selected().map(({ id }) => id);

    const request = !this.allSelected()
      ? this.proxyService.deleteByIds(ids)
      : this.proxyService.deleteAll({
          filterText: this.list.filter,
          ...this.filters,
        });

    return request.pipe(finalize(this.list.get));
  }

  delete(record: PartTestDto) {
    this.confirmationService
      .warn('::DeleteConfirmationMessage', '::AreYouSure', { messageLocalizationParams: [] })
      .pipe(
        filter(status => status === Confirmation.Status.confirm),
        switchMap(() => this.proxyService.delete(record.id)),
      )
      .subscribe(this.list.get);
  }

  bulkDelete() {
    if (this.selectedCount() < 1) {
      return;
    }

    let message = '::';
    let messageParam = null;

    if (this.allSelected()) {
      message += 'DeleteAllRecords';
    } else {
      message += 'DeleteSelectedRecords';
      messageParam = this.selectedCount().toString();
    }

    this.confirmationService
      .warn(message, 'AbpUi::AreYouSure', {
        messageLocalizationParams: [messageParam],
      })
      .pipe(
        filter(result => result === Confirmation.Status.confirm),
        switchMap(() => this.bulkDeleteRequest()),
      )
      .subscribe();
  }

  selectAll() {
    this.allSelected.set(!this.allSelected());
    this.selected.set(this.allSelected() ? [...this.data.items] : []);
  }

  onSelect({ selected }) {
    if (selected.length < 1) {
      this.clearAllSelection();
      return;
    }

    if (selected.length === this.data.totalCount) {
      this.allSelected.set(true);
      this.selected.set(selected);
      return;
    }

    if (selected.length !== this.data.totalCount && this.allSelected()) {
      this.allSelected.set(false);
    }

    if (selected.length === 1) {
      this.selected.set([...this.selected()]);
      return;
    }

    this.selected.set(selected);
  }

  hookToQuery() {
    const getData = (query: ABP.PageQueryParams) =>
      this.proxyService.getList({
        ...query,
        ...this.filters,
        filterText: query.filter,
      });

    const setData = (list: PagedResultDto<PartTestDto>) => {
      this.data = list;

      if (this.selectedCount() > 0) {
        this.clearAllSelection();
      }
    };

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetPartTestsInput;
    this.list.get();
  }

  exportToExcel() {
    this.isExportToExcelBusy = true;
    this.proxyService
      .getDownloadToken()
      .pipe(
        switchMap(({ token }) =>
          this.proxyService.getListAsExcelFile({
            downloadToken: token,
            filterText: this.list.filter,
            ...this.filters,
          }),
        ),
        finalize(() => (this.isExportToExcelBusy = false)),
      )
      .subscribe(result => {
        this.abpWindowService.downloadBlob(result, 'PartTest.xlsx');
      });
  }
}