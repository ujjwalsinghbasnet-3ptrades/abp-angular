import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { PartDto } from '../parts/models';

export interface GetIpbsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  figureName?: string;
  figureNumber?: string;
  toNumber?: string;
  indentureLevel?: string;
  sourceId?: string;
  relatedId?: string;
}

export interface IpbCreateDto {
  figureName: string;
  figureNumber: string;
  toNumber?: string;
  indentureLevel?: string;
  sourceId?: string;
  relatedId?: string;
}

export interface IpbDto extends FullAuditedEntityDto<string> {
  figureName: string;
  figureNumber: string;
  toNumber?: string;
  indentureLevel?: string;
  sourceId?: string;
  relatedId?: string;
  concurrencyStamp?: string;
}

export interface IpbUpdateDto {
  figureName: string;
  figureNumber: string;
  toNumber?: string;
  indentureLevel?: string;
  sourceId?: string;
  relatedId?: string;
  concurrencyStamp?: string;
}

export interface IpbWithNavigationPropertiesDto {
  ipb: IpbDto;
  related: PartDto;
  source: PartDto;
}
