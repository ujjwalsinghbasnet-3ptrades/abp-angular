import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface DocumentCreateDto {
  name: string;
  size: number;
  type?: string;
}

export interface DocumentDto extends FullAuditedEntityDto<string> {
  name: string;
  size: number;
  type?: string;
  concurrencyStamp?: string;
}

export interface DocumentExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  sizeMin?: number;
  sizeMax?: number;
  type?: string;
}

export interface DocumentUpdateDto {
  name: string;
  size: number;
  type?: string;
  concurrencyStamp?: string;
}

export interface GetDocumentsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  sizeMin?: number;
  sizeMax?: number;
  type?: string;
}
