import type {
  GetIpbsInput,
  IpbCreateDto,
  IpbDto,
  IpbUpdateDto,
  IpbWithNavigationPropertiesDto,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type {
  AppFileDescriptorDto,
  DownloadTokenResultDto,
  GetFileInput,
  LookupDto,
  LookupRequestDto,
} from '../shared/models';

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
      { apiName: this.apiName, ...config },
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/app/ipbs/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IpbDto>(
      {
        method: 'GET',
        url: `/api/app/ipbs/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/app/ipbs/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/ipbs/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetIpbsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<IpbWithNavigationPropertiesDto>>(
      {
        method: 'GET',
        url: '/api/app/ipbs',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          figureName: input.figureName,
          figureNumber: input.figureNumber,
          toNumber: input.toNumber,
          indentureLevel: input.indentureLevel,
          sourceId: input.sourceId,
          relatedId: input.relatedId,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getPartLookup = (input: LookupRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<LookupDto<string>>>(
      {
        method: 'GET',
        url: '/api/app/ipbs/part-lookup',
        params: {
          filter: input.filter,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getWithNavigationProperties = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IpbWithNavigationPropertiesDto>(
      {
        method: 'GET',
        url: `/api/app/ipbs/with-navigation-properties/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: string, input: IpbUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IpbDto>(
      {
        method: 'PUT',
        url: `/api/app/ipbs/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/app/ipbs/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
