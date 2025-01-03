import { Injectable } from '@angular/core';
import { AbstractIpbViewService } from './ipb.abstract.service';
import { ABP, PagedResultDto } from '@abp/ng.core';
import { map } from 'rxjs';

@Injectable()
export class IpbViewService extends AbstractIpbViewService {
  constructor() {
    super();
  }
  getIpbsForSource(sourceId: string) {
    return this.proxyService
      .getList({
        sourceId,
        maxResultCount: 1000,
      })
      .pipe(map((data) => data.items));
  }

  getIpbsForRelated(relatedId: string) {
    return this.proxyService
      .getList({
        relatedId,
        maxResultCount: 1000,
      })
      .pipe(map((data) => data.items));
  }

}
