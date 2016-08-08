import {Injectable} from '@angular/core';
import {Http} from '@angular/http';

@Injectable()
export class TroopService {

    public list() {
        return this.http.get('/api/troop')
            .map(response => response.json());
    }


    constructor(private http: Http) { }
    
}
