import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import type { PartTestDto } from '../../../proxy/part-tests/models';
import { PartTestService } from '../../../proxy/part-tests/part-test.service';

export abstract class AbstractPartTestDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);

  public readonly proxyService = inject(PartTestService);
  public readonly list = inject(ListService);

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  protected createRequest() {
    const formValues = {
      ...this.form.value,
    };

    if (this.selected) {
      return this.proxyService.update(this.selected.id, {
        ...formValues,
        concurrencyStamp: this.selected.concurrencyStamp,
      });
    }

    return this.proxyService.create(formValues);
  }

  buildForm() {
    const {
      partNumber,
      name,
      cageCode,
      distributionStatement,
      toNumber,
      smr,
      niin,
      fsc,
      wuc,
      uoc,
      uniqueId,
      nsn,
      imageUrl,
    } = this.selected || {};

    this.form = this.fb.group({
      partNumber: [partNumber ?? null, [Validators.required]],
      name: [name ?? null, [Validators.required]],
      cageCode: [cageCode ?? null, [Validators.required]],
      distributionStatement: [distributionStatement ?? null, [Validators.required]],
      toNumber: [toNumber ?? null, []],
      smr: [smr ?? null, []],
      niin: [niin ?? null, []],
      fsc: [fsc ?? null, []],
      wuc: [wuc ?? null, []],
      uoc: [uoc ?? null, []],
      uniqueId: [uniqueId ?? null, []],
      nsn: [nsn ?? null, []],
      imageUrl: [imageUrl ?? null, []],
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

  update(record: PartTestDto) {
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
