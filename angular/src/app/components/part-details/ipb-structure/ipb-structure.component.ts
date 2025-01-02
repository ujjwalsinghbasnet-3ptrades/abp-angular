import { Component, OnInit, signal } from '@angular/core';
import { TreeViewComponent } from '../../tree-view/tree-view.component';
import { CommonModule } from '@angular/common';
import { partColumns} from './parts';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import {
  NgbNavModule,
} from '@ng-bootstrap/ng-bootstrap';
import { PartIpbService } from 'src/app/parts/part/services/part-ipb.service';
import { ActivatedRoute } from '@angular/router';
import { IpbDto } from '@proxy/ipb';
import { getIpbParts } from 'src/utility/getIpbParts';

@Component({
  selector: 'app-ipb-structure',
  standalone: true,
  imports: [TreeViewComponent, CommonModule,ThemeSharedModule,NgbNavModule],
  templateUrl: './ipb-structure.component.html',
  styleUrl: './ipb-structure.component.scss',
  providers: [PartIpbService]
})
export class IpbStructureComponent implements OnInit{
  public parts: any[] = [];
  public columns: { name: string; field: string }[] = partColumns;
  public isVisible = false;
  public partId: string = '';
  public ipbs = signal<IpbDto[]>([]);
  public ipb = signal<IpbDto | null>(null);

  constructor(private readonly partIpbService: PartIpbService, private readonly route: ActivatedRoute) {
    this.route.params.subscribe(({ id }) => {
      this.partId = id;
    });
  }

  ngOnInit() {
    this.partIpbService.getIpbForSourcePart(this.partId).subscribe(ipbs => {
      this.ipbs.set(ipbs.items);
      const treePart = getIpbParts(ipbs.items)
      this.parts = treePart as any
    });
  }

  addHandler(event: any) {
    this.isVisible = true;

  }

  closeModal() {
    this.isVisible = false;
  }
}
