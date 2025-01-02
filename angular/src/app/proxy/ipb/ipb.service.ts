import { IpbCreateDto, IpbDto } from './models';
import { Injectable } from '@angular/core';
import { RestService, Rest } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class IpbService {
  apiName = 'Default';

  create = (input: IpbCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IpbDto>(
      {
        method: 'POST',
        url: '/api/app/ipbs',
        body: input,
      },
      { apiName: this.apiName, ...config }
    );

  getListWithNavigationProperties = (id: string) => this.restService.request<any, IpbDto>(
    {
      method: 'GET',
        url: `/api/app/ipbs/with-navigation-properties/${id}`,
      },
      { apiName: this.apiName }
    );

    getList = (config?: Partial<Rest.Config>) => this.restService.request<any, IpbDto[]>(
      {
        method: 'GET',
        url: '/api/app/ipbs',
      },
      { apiName: this.apiName, ...config }
    );

    getIpbForSourcePart = (sourcePartId: string, config?: Partial<Rest.Config>) => this.restService.request<any, { items: IpbDto[] }>(
      {
        method: 'GET',
        url: `/api/app/ipbs`,
        params: { SourcePart: sourcePartId },
      },
      { apiName: this.apiName, ...config }
    );
  constructor(private restService: RestService) {}
}
