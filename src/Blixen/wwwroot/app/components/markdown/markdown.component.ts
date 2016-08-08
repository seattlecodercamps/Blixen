import {Component, Input} from '@angular/core';
import * as marked from 'marked';
import {DomSanitizationService, SafeHtml} from '@angular/platform-browser';

import * as highlight from 'highlight.js';


@Component({
    moduleId: module.id,
    templateUrl: './app/components/markdown/markdown.component.html',
    styleUrls: ['./app/components/markdown/markdown.component.css'],
    selector: 'my-markdown'
})
export class MarkdownComponent {

    private md: MarkedStatic;

    private _inputText: string;
    
    public outputText: SafeHtml;

    public get inputText() {
        return this._inputText;
    }

    @Input()
    public set inputText(value) {
        this._inputText = value;
        this.outputText = this.sanitizer.bypassSecurityTrustHtml(this.md(value));
    }

    constructor(private sanitizer: DomSanitizationService) {
        this.md = marked;
        const renderer = new this.md.Renderer();
        renderer.code = (code, language) => {
            // Check whether the given language is valid for highlight.js.
            const validLang = !!(language && highlight.getLanguage(language));
            // Highlight only if the language is valid.
            const highlighted = validLang ? highlight.highlight(language, code).value : code;
            // Render the highlighted code with `hljs` class.
            return `<pre><code class="hljs ${language}">${highlighted}</code></pre>`;
        };

        // Set the renderer to marked.
        marked.setOptions({ renderer });
    }


}