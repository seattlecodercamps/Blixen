import { Component, OnInit } from '@angular/core';

import * as marked from 'marked';
import {MarkdownComponent} from '../../components/markdown/markdown.component';


@Component({
    templateUrl: './app/pages/home/home.component.html',
    directives: [MarkdownComponent]
})
export class HomeComponent {
    //private md: MarkedStatic;

    //constructor() {
    //    this.md = marked;

    //    console.log(this.md('__I am bold__!'));
    //}

   
}