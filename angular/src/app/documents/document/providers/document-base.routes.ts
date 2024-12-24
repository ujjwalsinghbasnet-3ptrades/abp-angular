import { ABP, eLayoutType } from '@abp/ng.core';

export const DOCUMENT_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/documents',
    iconClass: 'fas fa-file',
    name: '::Menu:Documents',
    layout: eLayoutType.application,
    requiredPolicy: 'AbpPoc.Documents',
    breadcrumbText: '::Documents',
  },
];
