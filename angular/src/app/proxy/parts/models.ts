import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetPartsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  description?: string;
  partNumber?: string;
  cageCode?: string;
  toNumber?: string;
  distributionStatement?: string;
  smr?: string;
  niin?: string;
  fsc?: string;
  wuc?: string;
  uoc?: string;
  uniqueId?: string;
  nsn?: string;
  imageUrl?: string;
}

export interface PartCreateDto {
  name: string;
  description?: string;
  partNumber: string;
  cageCode: string;
  toNumber: string;
  distributionStatement?: string;
  smr?: string;
  niin?: string;
  fsc?: string;
  wuc?: string;
  uoc?: string;
  uniqueId?: string;
  nsn: string;
  imageUrl?: string;
}

export interface PartDto extends FullAuditedEntityDto<string> {
  name: string;
  description?: string;
  partNumber: string;
  cageCode: string;
  toNumber: string;
  distributionStatement?: string;
  smr?: string;
  niin?: string;
  fsc?: string;
  wuc?: string;
  uoc?: string;
  uniqueId?: string;
  nsn: string;
  imageUrl?: string;
  concurrencyStamp?: string;
}

export interface PartExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
  description?: string;
  partNumber?: string;
  cageCode?: string;
  toNumber?: string;
  distributionStatement?: string;
  smr?: string;
  niin?: string;
  fsc?: string;
  wuc?: string;
  uoc?: string;
  uniqueId?: string;
  nsn?: string;
  imageUrl?: string;
}

export interface PartUpdateDto {
  name: string;
  description?: string;
  partNumber: string;
  cageCode: string;
  toNumber: string;
  distributionStatement?: string;
  smr?: string;
  niin?: string;
  fsc?: string;
  wuc?: string;
  uoc?: string;
  uniqueId?: string;
  nsn: string;
  imageUrl?: string;
  concurrencyStamp?: string;
}
