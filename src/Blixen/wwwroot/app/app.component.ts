import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';


@Component({
    moduleId: module.id,
    selector: 'app',
    templateUrl: './app/app.component.html',
    directives: [ROUTER_DIRECTIVES]
})
export class AppComponent {
}