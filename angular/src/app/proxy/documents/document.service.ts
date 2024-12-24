import type {
  DocumentCreateDto,
  DocumentDto,
  DocumentExcelDownloadDto,
  DocumentUpdateDto,
  GetDocumentsInput,
} from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { AppFileDescriptorDto, DownloadTokenResultDto, GetFileInput } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class DocumentService {
  apiName = 'Default';

  create = (input: DocumentCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DocumentDto>(
      {
        method: 'POST',
        url: '/api/app/documents',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: `/api/app/documents/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  deleteAll = (input: GetDocumentsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/documents/all',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          sizeMin: input.sizeMin,
          sizeMax: input.sizeMax,
          type: input.type,
        },
      },
      { apiName: this.apiName, ...config },
    );

  deleteByIds = (documentIds: string[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>(
      {
        method: 'DELETE',
        url: '/api/app/documents',
        params: { documentIds },
      },
      { apiName: this.apiName, ...config },
    );

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DocumentDto>(
      {
        method: 'GET',
        url: `/api/app/documents/${id}`,
      },
      { apiName: this.apiName, ...config },
    );

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>(
      {
        method: 'GET',
        url: '/api/app/documents/download-token',
      },
      { apiName: this.apiName, ...config },
    );

  getFile = (input: GetFileInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/documents/file',
        params: { downloadToken: input.downloadToken, fileId: input.fileId },
      },
      { apiName: this.apiName, ...config },
    );

  getList = (input: GetDocumentsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<DocumentDto>>(
      {
        method: 'GET',
        url: '/api/app/documents',
        params: {
          filterText: input.filterText,
          sorting: input.sorting,
          skipCount: input.skipCount,
          maxResultCount: input.maxResultCount,
          name: input.name,
          sizeMin: input.sizeMin,
          sizeMax: input.sizeMax,
          type: input.type,
        },
      },
      { apiName: this.apiName, ...config },
    );

  getListAsExcelFile = (input: DocumentExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>(
      {
        method: 'GET',
        responseType: 'blob',
        url: '/api/app/documents/as-excel-file',
        params: {
          downloadToken: input.downloadToken,
          filterText: input.filterText,
          name: input.name,
          sizeMin: input.sizeMin,
          sizeMax: input.sizeMax,
          type: input.type,
        },
      },
      { apiName: this.apiName, ...config },
    );

  update = (id: string, input: DocumentUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, DocumentDto>(
      {
        method: 'PUT',
        url: `/api/app/documents/${id}`,
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  uploadFile = (input: FormData, config?: Partial<Rest.Config>) =>
    this.restService.request<any, AppFileDescriptorDto>(
      {
        method: 'POST',
        url: '/api/app/documents/upload-file',
        body: input,
      },
      { apiName: this.apiName, ...config },
    );

  constructor(private restService: RestService) {}
}
