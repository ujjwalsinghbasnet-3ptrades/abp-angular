import { inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ListService, TrackByService } from '@abp/ng.core';

import { finalize, tap } from 'rxjs/operators';

import type { PartDto } from '../../../proxy/parts/models';
import { PartService } from '../../../proxy/parts/part.service';
import { IpbService } from '@proxy/ipbs/ipb.service';
import { firstValueFrom, from } from 'rxjs';

export abstract class AbstractPartDetailViewService {
  protected readonly fb = inject(FormBuilder);
  protected readonly track = inject(TrackByService);
  protected readonly ipbService = inject(IpbService);

  public readonly proxyService = inject(PartService);
  public readonly list = inject(ListService);

  isBusy = false;
  isVisible = false;
  selected = {} as any;
  form: FormGroup | undefined;

  protected async createRequest() {
    const formValues = {
      ...this.form.value,
    };

    if (this.selected) {
      return this.proxyService.update(this.selected.id, {
        ...formValues,
        concurrencyStamp: this.selected.concurrencyStamp,
      });
    }
    const createPartObservable = this.proxyService.create(formValues);
    const createdPart = await firstValueFrom(createPartObservable);
    if (createdPart) {
      await firstValueFrom(
        this.ipbService.create({
          sourceId: null,
          relatedId: createdPart?.id,
          figureName: createdPart.name,
          figureNumber: createdPart.partNumber,
        })
      );
    }
    return createdPart;
  }

  buildForm() {
    const {
      name,
      description,
      partNumber,
      cageCode,
      toNumber,
      distributionStatement,
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
      name: [name ?? null, [Validators.required, Validators.minLength(3)]],
      description: [description ?? null, []],
      partNumber: [partNumber ?? null, [Validators.required]],
      cageCode: [cageCode ?? null, [Validators.required]],
      toNumber: [toNumber ?? null, [Validators.required]],
      distributionStatement: [distributionStatement ?? null, []],
      smr: [smr ?? null, []],
      niin: [niin ?? null, []],
      fsc: [fsc ?? null, []],
      wuc: [wuc ?? null, []],
      uoc: [uoc ?? null, []],
      uniqueId: [uniqueId ?? null, []],
      nsn: [nsn ?? null, [Validators.required]],
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

  update(record: PartDto) {
    this.selected = record;
    this.showForm();
  }

  hideForm() {
    this.isVisible = false;
  }

  submitForm() {
    if (this.form.invalid) return;

    this.isBusy = true;

    const request = from(this.createRequest()).pipe(
      finalize(() => (this.isBusy = false)),
      tap(() => this.hideForm())
    );

    request.subscribe(this.list.get);
  }

  changeVisible($event: boolean) {
    this.isVisible = $event;
  }
}
