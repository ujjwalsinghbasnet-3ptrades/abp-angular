import { inject } from '@angular/core';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { ABP, ListService, PagedResultDto } from '@abp/ng.core';
import { filter, switchMap, tap } from 'rxjs/operators';
import type { GetIpbsInput, IpbWithNavigationPropertiesDto } from '../../../proxy/ipbs/models';
import { IpbService } from '../../../proxy/ipbs/ipb.service';

export abstract class AbstractIpbViewService {
  protected readonly proxyService = inject(IpbService);
  protected readonly confirmationService = inject(ConfirmationService);
  protected readonly list = inject(ListService);

  data: PagedResultDto<IpbWithNavigationPropertiesDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetIpbsInput;

  delete(record: IpbWithNavigationPropertiesDto) {
    return this.confirmationService
      .warn('::DeleteConfirmationMessage', '::AreYouSure', { messageLocalizationParams: [] })
      .pipe(
        filter(status => status === Confirmation.Status.confirm),
        switchMap(() => this.proxyService.delete(record.ipb.id))
      )
      .pipe(tap(() => this.list.get()));
  }

  hookToQuery() {
    const getData = (query: ABP.PageQueryParams) =>
      this.proxyService.getList({
        ...query,
        ...this.filters,
        filterText: query.filter,
      });

    const setData = (list: PagedResultDto<IpbWithNavigationPropertiesDto>) => {
      this.data = list;
    };

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetIpbsInput;
    this.list.get();
  }
}
