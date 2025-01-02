import { FullAuditedEntityDto } from "@abp/ng.core";
import { PartDto } from "@proxy/parts";

export interface IpbDto extends FullAuditedEntityDto<string> {
    ipbIndex: string;
    figureName: string;
    figureNumber: string;
    toNumber?: string;
    indentureLevel?: string;
    sourceId: string;
    relatedId: string;
    sourcePart?: PartDto;
    relatedPart?: PartDto;
  }


  export interface IpbCreateDto {
    ipbIndex: string;
    figureName: string;
    figureNumber: string;
    toNumber?: string;
    indentureLevel?: string;
    sourceId: string;
    relatedId: string;
    sourcePart: string;
    relatedPart: string;
  }
