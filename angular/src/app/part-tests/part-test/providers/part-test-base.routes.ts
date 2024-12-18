import { ABP, eLayoutType } from '@abp/ng.core';

export const PART_TEST_BASE_ROUTES: ABP.Route[] = [
  {
    path: '/part-tests',
    iconClass: 'fas fa-file-alt',
    name: '::Menu:PartTests',
    layout: eLayoutType.application,
    requiredPolicy: 'AbpPoc.PartTests',
    breadcrumbText: '::PartTests',
  },
];
