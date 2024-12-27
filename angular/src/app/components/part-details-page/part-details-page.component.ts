import { PageModule } from '@abp/ng.components/page';
import { ListService } from '@abp/ng.core';
import { CommonModule } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PartDto, PartService } from '@proxy/parts';
import { PartDetailModalComponent } from 'src/app/parts/part/components/part-detail.component';
import { PartDetailViewService } from 'src/app/parts/part/services/part-detail.service';
import { PartViewService } from 'src/app/parts/part/services/part.service';

@Component({
  selector: 'app-part-details-page',
  standalone: true,
  imports: [PageModule, CommonModule, PartDetailModalComponent],
  templateUrl: './part-details-page.component.html',
  styleUrl: './part-details-page.component.scss',
  providers: [ListService, PartDetailViewService, PartViewService],
})
export class PartDetailsPageComponent implements OnInit {
  constructor(private route: ActivatedRoute, public partDetailService: PartDetailViewService, public partService: PartViewService, private router: Router) {}
  partId: string = '';
  part = signal<PartDto | null>(null);

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.partId = params['id'];
    });
    this.partDetailService.getPart(this.partId).subscribe(part => {
      this.part.set(part);
    });
  }

  submitDetailPageForm() {
    this.partDetailService.submitDetailForm().subscribe(part =>
      this.partDetailService.getPart(this.partId).subscribe(part => {
        this.part.set(part);
      })
    );
  }

  updatePart() {
    this.partDetailService.update(this.part());
  }

  deletePart() {
    this.partService.delete(this.part()!).subscribe(() => {
      this.router.navigate(['/parts']);
    });
  }
}
