import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { KENDO_WINDOW } from '@progress/kendo-angular-dialog';
import { TextBoxModule } from '@progress/kendo-angular-inputs';
import { KENDO_BUTTON } from '@progress/kendo-angular-buttons';

@Component({
  selector: 'app-windows-dialog',
  standalone: true,
  imports: [KENDO_WINDOW, CommonModule, TextBoxModule,KENDO_BUTTON],
  templateUrl: './windows-dialog.component.html',
  styleUrl: './windows-dialog.component.scss',
})
export class WindowsDialogComponent {
  public opened = false;
  public dataSaved = false;

  public close(event: any): void {
    event.stopPropagation();
    this.opened = false;
  }

  public open(event: any): void {
    event.stopPropagation();
    this.opened = true;
  }

  public submit(event: any): void {
    event.stopPropagation();
    this.dataSaved = true;
    this.close(event);
  }
}
