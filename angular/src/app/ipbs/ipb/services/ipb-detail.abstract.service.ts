import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import type { IpbWithNavigationPropertiesDto } from '../../../proxy/ipbs/models';
import { IpbService } from '../../../proxy/ipbs/ipb.service';

export abstract class AbstractIpbDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(IpbService);
  public readonly list = inject(ListService);

  public readonly getPartLookup = this.proxyService.getPartLookup;


  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  protected createRequest() {
    const formValues = {
      ...this.form.value,
    };

    if (this.selected) {
      return this.proxyService.update(this.selected.ipb.id, {
        ...formValues,
        concurrencyStamp: this.selected.ipb.concurrencyStamp,
      });
    }

    return this.proxyService.create(formValues);
  }

  buildForm() {
    const { figureName, figureNumber, toNumber, indentureLevel, sourceId, relatedId } =
      this.selected?.ipb || {};

    this.form = this.fb.group({
      figureName: [figureName ?? null, [Validators.required, Validators.maxLength(256)]],
      figureNumber: [figureNumber ?? null, [Validators.required, Validators.maxLength(32)]],
      toNumber: [toNumber ?? null, [Validators.maxLength(512)]],
      indentureLevel: [indentureLevel ?? null, [Validators.maxLength(8)]],
      sourceId: [sourceId ?? null, []],
      relatedId: [relatedId ?? null, []],
    });
  }

  showForm() {
    this.buildForm();
    this.isVisible = true;
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: IpbWithNavigationPropertiesDto) {
    this.selected = record;
    this.showForm();
  }

  hideForm() {
    this.isVisible = false;
  }

  submitForm() {
    if (this.form.invalid) return;

    this.isBusy = true;

    const request = this.createRequest().pipe(
      finalize(() => (this.isBusy = false)),
      tap(() => this.hideForm()),
    );

    request.subscribe(this.list.get);
  }

  changeVisible($event: boolean) {
    this.isVisible = $event;
  }
}
