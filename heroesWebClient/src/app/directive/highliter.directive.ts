import { Directive, ElementRef, OnInit } from '@angular/core';

@Directive({
  selector: '[appHighliter]',
  standalone: false,
})
export class HighliterDirective implements OnInit {
  constructor(private ef: ElementRef) {}
  ngOnInit(): void {
    console.log(this.ef.nativeElement.innerText);
    this.ef.nativeElement.style = `color: red;font-weight: 900;border: 2px dotted black;margin: 45px;` ;
  }
}
