import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/delay';

@Injectable()
export class AuthService {
    public get isLoggedIn(): boolean {
        return localStorage.getItem('userName');
    }

    // store the URL so we can redirect after logging in
    redirectUrl: string;

    login(user) {
        //return Observable.of(true).delay(1000).do(val => this.isLoggedIn = true);
        return this.http.post('/api/account/login', user).map((user:any) => {
            localStorage.setItem('userName', user.name);
        });
    }

    logout() {
        this.isLoggedIn = false;
    }

    constructor(private http: Http) { }
}