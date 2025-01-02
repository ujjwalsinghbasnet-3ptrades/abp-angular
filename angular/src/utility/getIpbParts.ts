import { IpbDto } from "@proxy/ipb";
  
export interface IbpTree extends IpbDto {
    ipb: IpbDto;
  }
  
  export function getIpbParts(ipbs: IpbDto[]): IbpTree[] {
    const result: any[] = [];
  
    function traverse(ipb: IbpTree): void {
      if (ipb.relatedPart) {
        const modifiedPart = {
          ...ipb.ipb,
          ...ipb.relatedPart
        }
        result.push(modifiedPart);
      }
    }
    
    for (const ipb of ipbs) {
      traverse(ipb as IbpTree);
    }
  
    return [ipbs[0].sourcePart, ...result];
  }