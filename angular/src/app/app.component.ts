import { ReplaceableComponentsService } from '@abp/ng.core';
import { BreadcrumbComponent } from '@abp/ng.theme.shared';
import { Component } from '@angular/core';
import { eThemeLeptonXComponents } from '@volosoft/abp.ng.theme.lepton-x';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <abp-dynamic-layout></abp-dynamic-layout>
    <abp-gdpr-cookie-consent></abp-gdpr-cookie-consent>
  `,
})
export class AppComponent {
  constructor(private replaceableComponents: ReplaceableComponentsService) {
    // this.replaceableComponents.add({
    //   component: BreadcrumbComponent,
    //   key: eThemeLeptonXComponents.Breadcrumb,
    // });
  }
}
