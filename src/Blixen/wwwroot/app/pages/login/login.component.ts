import {Component} from '@angular/core';
import {AuthService} from '../../services/auth.service';
import { Router }  from '@angular/router';

@Component({
    templateUrl: './app/pages/login/login.component.html'
})
export class LoginComponent {
    public user = {};

    public login() {
        this.authService.login(this.user).subscribe(() => {
            // Get the redirect URL from our auth service
            // If no redirect has been set, use the default
            let redirect = this.authService.redirectUrl ? this.authService.redirectUrl : '/troops';

            // Redirect the user
            this.router.navigate([redirect]);
        });
    }

    constructor(private authService: AuthService, private router: Router) { }

}