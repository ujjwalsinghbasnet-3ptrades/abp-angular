import { CommonModule } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { PartDto } from '@proxy/parts';
import { PermissionDirective } from 'src/app/directives/cardActionDirectives';
import { PartDetailViewService } from 'src/app/parts/part/services/part-detail.service';
import { PartViewService } from 'src/app/parts/part/services/part.service';

@Component({
  selector: 'app-overview',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, CommonModule, PermissionDirective],
  templateUrl: './overview.component.html',
  styleUrl: './overview.component.scss',
})
export class OverviewComponent implements OnInit {
  partId: string = '';
  part = signal<PartDto | null>(null);
  isEditing = signal<boolean>(false);

  constructor(
    private route: ActivatedRoute,
    public partDetailService: PartDetailViewService,
    public partService: PartViewService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadPartDetails();
  }

  private loadPartDetails() {
    this.route.params.subscribe(({ id }) => {
      this.partId = id;
      this.partDetailService.getPart(this.partId).subscribe(part => {
        this.partDetailService.selected = part;
        this.part.set(part);
        this.initializeForm();
      });
    });
  }

  private initializeForm() {
    this.partDetailService.buildForm();
    this.partDetailService.form.disable();
  }

  toggleEditing() {
    const editing = !this.isEditing();
    this.isEditing.set(editing);

    if (editing) {
      this.partDetailService.form.enable();
    } else {
      this.cancelEditing();
    }
  }

  updateChanges() {
    if (this.partDetailService.form.invalid) return;

    this.partDetailService.submitDetailForm().subscribe(() => {
      this.refreshPartDetails();
    });
  }

  deletePart() {
    this.partService.delete(this.part()!).subscribe(() => {
      this.router.navigate(['/parts']);
    });
  }

  cancelEditing() {
    this.refreshPartDetails();
  }

  private refreshPartDetails() {
    this.partDetailService.getPart(this.partId).subscribe(part => {
      this.part.set(part);
      this.partDetailService.selected = part;
      this.partDetailService.buildForm();
      this.isEditing.set(false);
      this.partDetailService.form.disable();
    });
  }

  getFormControls(): string[] {
    return Object.keys(this.partDetailService.form?.controls || {});
  }

  getFieldType(controlName: string): string {
    return typeof this.partDetailService.form.get(controlName)?.value;
  }
}
