import { APP_INITIALIZER, inject } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { IPB_BASE_ROUTES } from './ipb-base.routes';

export const IPBS_IPB_ROUTE_PROVIDER = [
  {
    provide: APP_INITIALIZER,
    multi: true,
    useFactory: configureRoutes,
  },
];

function configureRoutes() {
  const routesService = inject(RoutesService);

  return () => {
    const routes: ABP.Route[] = [...IPB_BASE_ROUTES];
    routesService.add(routes);
  };
}
