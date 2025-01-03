import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter, TimeAdapter } from '@abp/ng.theme.shared';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { ChangeDetectionStrategy, Component, inject, Input } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import {
  NgbNavModule,
  NgbDatepickerModule,
  NgbTimepickerModule,
  NgbDateAdapter,
  NgbTimeAdapter,
} from '@ng-bootstrap/ng-bootstrap';
import { IpbDetailViewService } from '../services/ipb-detail.service';

@Component({
  selector: 'app-ipb-detail-modal',
  changeDetection: ChangeDetectionStrategy.Default,
  standalone: true,
  imports: [
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    ReactiveFormsModule,
    NgbDatepickerModule,
    NgbTimepickerModule,
    NgbNavModule,
  ],
  providers: [
    { provide: NgbDateAdapter, useClass: DateAdapter },
    { provide: NgbTimeAdapter, useClass: TimeAdapter },
  ],
  templateUrl: './ipb-detail.component.html',
  styles: [],
})
export class IpbDetailModalComponent {
  public readonly service = inject(IpbDetailViewService);
  @Input() submitHandler?: () => void;

  submit() {
    if (this.submitHandler) {
      return this.submitHandler();
    }
    return this.service.submitForm();
  }
}
