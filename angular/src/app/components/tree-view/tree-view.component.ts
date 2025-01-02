import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import {
  ExcelModule,
  FlatBindingDirective,
  PDFModule,
  SelectableSettings,
  TreeListModule,
} from '@progress/kendo-angular-treelist';
import { fileExcelIcon, filePdfIcon, SVGIcon } from '@progress/kendo-svg-icons';
import { CommonModule } from '@angular/common';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { InputsModule } from '@progress/kendo-angular-inputs';

@Component({
  selector: 'app-tree-view',
  standalone: true,
  imports: [TreeListModule, ButtonsModule, ExcelModule, PDFModule, InputsModule, CommonModule],
  templateUrl: './tree-view.component.html',
  styleUrl: './tree-view.component.scss',
})
export class TreeViewComponent {
  @ViewChild(FlatBindingDirective) dataBinding: FlatBindingDirective;
  @Input() data: any[] = [];
  @Input() addLabel?: string = 'Add New';
  @Input() columns: { name: string; field: string }[] = [];
  @Output() add: EventEmitter<any> = new EventEmitter<any>();

  public fileExcelIcon: SVGIcon = fileExcelIcon;
  public filePdfIcon: SVGIcon = filePdfIcon;

  public selected: any[] = [];

  public settings: SelectableSettings = {
    mode: 'row',
    multiple: true,
    drag: false,
  };

  public onFilter(value: string): void {
    this.dataBinding.filter = {
      logic: 'or',
      filters: [
        {
          field: 'name',
          operator: 'contains',
          value: value,
        },
        {
          field: 'cageCode',
          operator: 'contains',
          value: value,
        },
        {
          field: 'description',
          operator: 'contains',
          value: value,
        },
      ],
    };
    this.dataBinding.rebind();
  }
  addHandler(event: any) {
    this.add.emit(event);
  }
}
