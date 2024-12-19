import { ABP, eLayoutType } from '@abp/ng.core';

export const PART_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/parts',
    iconClass: 'fa fa-light fa-cogs fa-lg',
    name: '::Menu:Parts',
    layout: eLayoutType.application,
    requiredPolicy: 'AbpPoc.Parts',
    breadcrumbText: '::Parts',
  },
];
