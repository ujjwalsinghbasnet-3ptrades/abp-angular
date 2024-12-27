import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-widget-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './widget-form.component.html',
  styleUrl: './widget-form.component.scss',
})
export class WidgetFormComponent {
  private formBuilder = inject(FormBuilder);

  widgetForm: FormGroup = this.formBuilder.group({
    widgetName: ['', Validators.required],
    widgetCols: [1, [Validators.required, Validators.min(1)]],
    widgetRows: [1, [Validators.required, Validators.min(1)]],
    widgetDescription: [''],
    widgetType: ['', Validators.required],
    widgetUrl: ['', this.urlValidator()],
  });

  constructor() {
    this.widgetForm.get('widgetType')?.valueChanges.subscribe(type => {
      const widgetUrlControl = this.widgetForm.get('widgetUrl');

      if (type === 'External') {
        widgetUrlControl?.setValidators([Validators.required, Validators.pattern(/https?:\/\/.*/)]);
      } else {
        widgetUrlControl?.clearValidators();
      }
      widgetUrlControl?.updateValueAndValidity();
    });
  }

  onSubmit() {
    if (this.widgetForm.valid) {
      console.log(this.widgetForm.value);
    } else {
      console.error('Form is invalid');
    }
  }

  private urlValidator() {
    return (control: any) => {
      const urlPattern = /https?:\/\/.*/;
      if (control.value && !urlPattern.test(control.value)) {
        return { invalidUrl: true };
      }
      return null;
    };
  }
}
