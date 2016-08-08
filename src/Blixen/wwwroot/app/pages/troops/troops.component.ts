import {Component, OnInit} from '@angular/core';
import {TroopService} from '../../services/troop.service';

@Component({
    moduleId: module.id,
    templateUrl: './app/pages/troops/troops.component.html',
    providers: [TroopService]
})
export class TroopsComponent extends OnInit {

    public troops;

    ngOnInit() {
        this.troopService.list().subscribe((troops) => {
            this.troops = troops
        });
    }

    constructor(private troopService: TroopService) {
        super();
    }

}
