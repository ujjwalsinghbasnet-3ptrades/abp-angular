import { IpbDto } from "@proxy/ipbs/models";
import { PartDto } from "@proxy/parts/models";
  

interface IbpTree {
  ipb: IpbDto;
  related: PartDto;
  source: PartDto;
}
  

  export function getIpbParts(ipbs: IbpTree[]): any[] {
    const result: any[] = [];
    function traverse(ipb: IbpTree): void {
      if (ipb.related && ipb.source) {
        const modifiedPart = {
          figureName:ipb.ipb.figureName,
          figureNumber:ipb.ipb.figureNumber,
          toNumber:ipb.ipb.toNumber,
          indentureLevel:ipb.ipb.indentureLevel,
          ...ipb.related,
          id: ipb.ipb.id,
          relatedId: ipb.related?.id,
          sourceId: ipb.source?.id,
          concurrencyStamp: ipb.ipb.concurrencyStamp,
        }
        result.push(modifiedPart);
      }
    }
    
    for (const ipb of ipbs) {
      traverse(ipb as IbpTree);
    }
  
    return result;
  }
