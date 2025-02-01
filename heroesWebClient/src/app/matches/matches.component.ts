import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { interval } from 'rxjs';

@Component({
  selector: 'app-matches',
  standalone: false,

  templateUrl: './matches.component.html',
  styleUrl: './matches.component.css',
})
export class MatchesComponent implements OnInit, OnDestroy {
  t: any;
  ngOnDestroy(): void {
    clearInterval(this.t);
  }
  @Input() data: any = {};
  expireInSec = 500;
  ngOnInit(): void {
    this.expireInSec = this.data.expireTimeSec;
    console.log(this.data);
    const t1 = (this.data.expireTimeSec* 1000)
    console.log(t1);
    this.t = setInterval(() => {
      this.expireInSec -= 1;
    }, t1 );
  }
}
