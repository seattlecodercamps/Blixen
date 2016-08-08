import { bootstrap } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';

import { AppComponent } from './app.component';
import { APP_ROUTER_PROVIDERS } from './app.routes';
import { disableDeprecatedForms, provideForms } from '@angular/forms';

// Extend Observable through the app
import 'rxjs/Rx';

//enableProdMode();

bootstrap(AppComponent, [
    disableDeprecatedForms(),
    provideForms(),
    APP_ROUTER_PROVIDERS
]).catch(console.error.bind(console));