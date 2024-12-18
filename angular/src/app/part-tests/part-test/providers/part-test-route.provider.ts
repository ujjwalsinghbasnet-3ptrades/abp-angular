import { APP_INITIALIZER, inject } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { PART_TEST_BASE_ROUTES } from './part-test-base.routes';

export const PART_TESTS_PART_TEST_ROUTE_PROVIDER = [
  {
    provide: APP_INITIALIZER,
    multi: true,
    useFactory: configureRoutes,
  },
];

function configureRoutes() {
  const routesService = inject(RoutesService);

  return () => {
    const routes: ABP.Route[] = [...PART_TEST_BASE_ROUTES];
    routesService.add(routes);
  };
}
