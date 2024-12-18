import type {
  GetPartTestsInput,
  PartTestCreateDto,
  PartTestDto,
  PartTestExcelDownloadDto,
  PartTestUpdateDto,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AppFileDescriptorDto, DownloadTokenResultDto, GetFileInput } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class PartTestService {
  apiName = 'Default';

  create = (input: PartTestCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PartTestDto>(
      {
        method: 'POST',
        url: '/api/app/part-tests',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/app/part-tests/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetPartTestsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/part-tests/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          partNumber: input.partNumber,
          name: input.name,
          cageCode: input.cageCode,
          distributionStatement: input.distributionStatement,
          toNumber: input.toNumber,
          smr: input.smr,
          niin: input.niin,
          fsc: input.fsc,
          wuc: input.wuc,
          uoc: input.uoc,
          uniqueId: input.uniqueId,
          nsn: input.nsn,
          imageUrl: input.imageUrl,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (partTestIds: string[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/part-tests',
        params: { partTestIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PartTestDto>(
      {
        method: 'GET',
        url: `/api/app/part-tests/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/app/part-tests/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/part-tests/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetPartTestsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<PartTestDto>>(
      {
        method: 'GET',
        url: '/api/app/part-tests',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          partNumber: input.partNumber,
          name: input.name,
          cageCode: input.cageCode,
          distributionStatement: input.distributionStatement,
          toNumber: input.toNumber,
          smr: input.smr,
          niin: input.niin,
          fsc: input.fsc,
          wuc: input.wuc,
          uoc: input.uoc,
          uniqueId: input.uniqueId,
          nsn: input.nsn,
          imageUrl: input.imageUrl,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (input: PartTestExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/part-tests/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          partNumber: input.partNumber,
          name: input.name,
          cageCode: input.cageCode,
          distributionStatement: input.distributionStatement,
          toNumber: input.toNumber,
          smr: input.smr,
          niin: input.niin,
          fsc: input.fsc,
          wuc: input.wuc,
          uoc: input.uoc,
          uniqueId: input.uniqueId,
          nsn: input.nsn,
          imageUrl: input.imageUrl,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: string, input: PartTestUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PartTestDto>(
      {
        method: 'PUT',
        url: `/api/app/part-tests/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/app/part-tests/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
