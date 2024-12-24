import { APP_INITIALIZER, inject } from '@angular/core';
import { ABP, RoutesService } from '@abp/ng.core';
import { DOCUMENT_BASE_ROUTES } from './document-base.routes';

export const DOCUMENTS_DOCUMENT_ROUTE_PROVIDER = [
  {
    provide: APP_INITIALIZER,
    multi: true,
    useFactory: configureRoutes,
  },
];

function configureRoutes() {
  const routesService = inject(RoutesService);

  return () => {
    const routes: ABP.Route[] = [...DOCUMENT_BASE_ROUTES];
    routesService.add(routes);
  };
}
