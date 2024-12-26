import { Injectable } from '@angular/core';
import { AbstractPartDetailViewService } from './part-detail.abstract.service';
import { finalize, tap } from 'rxjs/operators';

@Injectable()
export class PartDetailViewService extends AbstractPartDetailViewService {
  constructor() {
    super();
  }
  getPart(id: string) {
    return this.proxyService.get(id);
  }

  submitDetailForm() {
    if (this.form.invalid) return;

    this.isBusy = true;

    const request = this.createRequest().pipe(
      finalize(() => (this.isBusy = false)),
      tap(() => this.hideForm())
    );
    return request
  }
}
