import { Injectable } from '@angular/core';
import {Http} from '@angular/http';

@Injectable()
export class CampService {

    public getCamp(campId: number) {
        return this.http.get('/api/camp/' + campId); 
    }


    constructor(private http: Http) { }
}


