import { provideRouter, RouterConfig } from '@angular/router';
import { AuthGuard } from './services/auth-guard.service';
import { AuthService } from './services/auth.service';
import { HTTP_PROVIDERS} from '@angular/http';



import { HomeComponent } from './pages/home/home.component';
import { AboutComponent } from './pages/about/about.component';
import { CampComponent } from './pages/camp/camp.component';
import { TroopsComponent } from './pages/troops/troops.component';
import { LoginComponent } from './pages/login/login.component';



const routes: RouterConfig = [
    { path: '', component: HomeComponent },
    { path: 'about', component: AboutComponent },
    { path: 'camp', component: CampComponent },
    { path: 'troops', component: TroopsComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent }


];

export const APP_ROUTER_PROVIDERS = [
    provideRouter(routes), AuthGuard, AuthService, HTTP_PROVIDERS
];