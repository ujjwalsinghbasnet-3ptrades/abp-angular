import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetPartTestsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  partNumber?: string;
  name?: string;
  cageCode?: string;
  distributionStatement?: string;
  toNumber?: string;
  smr?: string;
  niin?: string;
  fsc?: string;
  wuc?: string;
  uoc?: string;
  uniqueId?: string;
  nsn?: string;
  imageUrl?: string;
}

export interface PartTestCreateDto {
  partNumber: string;
  name: string;
  cageCode: string;
  distributionStatement: string;
  toNumber?: string;
  smr?: string;
  niin?: string;
  fsc?: string;
  wuc?: string;
  uoc?: string;
  uniqueId?: string;
  nsn?: string;
  imageUrl?: string;
}

export interface PartTestDto extends FullAuditedEntityDto<string> {
  partNumber: string;
  name: string;
  cageCode: string;
  distributionStatement: string;
  toNumber?: string;
  smr?: string;
  niin?: string;
  fsc?: string;
  wuc?: string;
  uoc?: string;
  uniqueId?: string;
  nsn?: string;
  imageUrl?: string;
  concurrencyStamp?: string;
}

export interface PartTestExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  partNumber?: string;
  name?: string;
  cageCode?: string;
  distributionStatement?: string;
  toNumber?: string;
  smr?: string;
  niin?: string;
  fsc?: string;
  wuc?: string;
  uoc?: string;
  uniqueId?: string;
  nsn?: string;
  imageUrl?: string;
}

export interface PartTestUpdateDto {
  partNumber: string;
  name: string;
  cageCode: string;
  distributionStatement: string;
  toNumber?: string;
  smr?: string;
  niin?: string;
  fsc?: string;
  wuc?: string;
  uoc?: string;
  uniqueId?: string;
  nsn?: string;
  imageUrl?: string;
  concurrencyStamp?: string;
}
