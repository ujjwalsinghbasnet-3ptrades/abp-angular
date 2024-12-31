import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { KENDO_CARD } from '@progress/kendo-angular-layout';
import { Router } from '@angular/router';
import { PermissionDirective } from 'src/app/directives/cardActionDirectives';

@Component({
  selector: 'app-default-card',
  standalone: true,
  imports: [KENDO_CARD, CommonModule,ThemeSharedModule, PermissionDirective],
  templateUrl: './default-card.component.html',
  styleUrl: './default-card.component.scss',
})
export class DefaultCardComponent {
  @Input() title: string = '';
  @Input() imageUrl: string | null = null;
  @Input() link: string | null = null;
  @Input() iconClassName: string = 'fa-thin fa-gears fa-10x';
  @Input() cardBody: Record<string, any> = {};
  @Input() dataItem: any;
  @Input() renderCustomBody?: () => string;
  @Input() cardActionProps: any;
  @Output() splitActions = new EventEmitter<any>();
  @Input() routerLink!: any[];

  constructor(private router: Router) {
  }

  camelCaseToTitleCase(str: string): string {
    return str.replace(/([a-z])([A-Z])/g, '$1 $2').replace(/^./, char => char.toUpperCase());
  }

  handleCardClick(): void {
    this.router.navigate(this.routerLink);
  }
}
