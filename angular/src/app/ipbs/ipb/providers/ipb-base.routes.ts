import { ABP, eLayoutType } from '@abp/ng.core';

export const IPB_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/ipbs',
    iconClass: 'fas fa-file-alt',
    name: '::Menu:Ipbs',
    layout: eLayoutType.application,
    requiredPolicy: 'AbpPoc.Ipbs',
    breadcrumbText: '::Ipbs',
  },
];
