import { Component } from '@angular/core';
import { TreeViewComponent } from '../../tree-view/tree-view.component';
import { CommonModule } from '@angular/common';
import { partColumns, PartForTreeView, parts } from './parts';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import {
  NgbNavModule,
} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-ipb-structure',
  standalone: true,
  imports: [TreeViewComponent, CommonModule,ThemeSharedModule,NgbNavModule],
  templateUrl: './ipb-structure.component.html',
  styleUrl: './ipb-structure.component.scss'
})
export class IpbStructureComponent {
  public parts: PartForTreeView[] = parts;
  public columns: { name: string; field: string }[] = partColumns;
  public isVisible = false;

  addHandler(event: any) {
    this.isVisible = true;

  }

  closeModal() {
    this.isVisible = false;
  }
}
