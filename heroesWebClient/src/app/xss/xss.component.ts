import { Component } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Component({
  selector: 'app-xss',
  standalone: false,

  templateUrl: './xss.component.html',
  styleUrl: './xss.component.css',
})
export class XssComponent {
  userInput: string = `<div style="color:red"> Test </div><button onclick="alert('XSS Attack Blocked!')">Click Me</button>`;
  // safeHTML: SafeHtml;

  constructor(private sanitizer: DomSanitizer) {
    // this.safeHTML = this.sanitizer.bypassSecurityTrustHtml(this.userInput);

  }
}

