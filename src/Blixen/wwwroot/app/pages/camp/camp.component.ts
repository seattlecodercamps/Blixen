import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {CampService} from '../../services/camp.service';

@Component({
    moduleId: module.id,
    templateUrl: './camp.component.html',
    providers: [CampService]
})
export class CampComponent extends OnInit {
    private campId: number;
    public camp;
     

    ngOnInit() {
        this.campService.getCamp(this.campId).toPromise()
            .then((camp) => this.camp = camp);
    }

    constructor(route: ActivatedRoute, private campService: CampService) {
        super();
        this.campId = route.snapshot.params['campId'];
    }

}