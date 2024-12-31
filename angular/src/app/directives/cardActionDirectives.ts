import { PermissionService } from '@abp/ng.core';
import { Directive, Input, OnInit, TemplateRef, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appPermission]',
  standalone: true,
})
export class PermissionDirective implements OnInit {
  @Input('appPermission') policy: string;

  constructor(
    private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef,
    private permissionService: PermissionService
  ) {}

  ngOnInit() {
    if (this.permissionService.getGrantedPolicy(this.policy)) {
      this.viewContainer.createEmbeddedView(this.templateRef);
    } else {
      this.viewContainer.clear();
    }
  }
}
