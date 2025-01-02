

import { IpbCreateDto, IpbDto, IpbService } from "@proxy/ipb";
import { Injectable } from "@angular/core";

@Injectable()
export class PartIpbService {
    constructor(private readonly ipbService: IpbService) {}

    getListWithNavigationProperties(id: string) {
        return this.ipbService.getListWithNavigationProperties(id);
    }

    create(input: IpbCreateDto) {
        return this.ipbService.create(input);
    } 

    getIpbForSourcePart(sourcePartId: string) {
        return this.ipbService.getIpbForSourcePart(sourcePartId);
    }
}
