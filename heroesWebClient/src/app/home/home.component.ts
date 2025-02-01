import {
  Component,
  OnDestroy,
  OnInit,
  ViewChild,
  ViewContainerRef,
} from '@angular/core';
import { Observable, Subscriber, Subscription } from 'rxjs';
import { MatchesComponent } from '../matches/matches.component';

@Component({
  selector: 'app-home',
  standalone: false,

  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit, OnDestroy {
  matchesList = [
    { match_id: 1, hero_name: 'Superman', hero_location: 'Metropolis', villain_name: 'Lex Luthor', villain_location: 'Metropolis', ground: 'Metropolis Arena', }, { match_id: 2, hero_name: 'Wonder Woman', hero_location: 'Themyscira', villain_name: 'Ares', villain_location: 'Themyscira', ground: 'Themyscira Coliseum', }, { match_id: 3, hero_name: 'Batman', hero_location: 'Gotham', villain_name: 'Joker', villain_location: 'Gotham', ground: 'Gotham City Square', },

  ];
  interval: any;

  displayMatch = 0;

  @ViewChild('matches', { read: ViewContainerRef, static: true })
  matchesContainer!: ViewContainerRef;

  ngOnInit(): void {
    this.loadDynamicComponent();
    this.getOtherMatches();
  }
  loadDynamicComponent() {
    this.matchesContainer.clear();
    const curMatch = this.matchesList[this.displayMatch];
    this.displayMatch += 1;
    if (this.displayMatch >= this.matchesList.length) {
      this.displayMatch = 0;
    }
    const contRef = this.matchesContainer.createComponent(MatchesComponent);
    contRef.instance.data = { ...curMatch, expireTimeSec: 3 };
  }
  getOtherMatches() {
    this.interval = setInterval(() => {
      this.loadDynamicComponent();
    }, 5000);
  }
  ngOnDestroy() {
    clearInterval(this.interval);
  }
}

// learning code here...
// export class HomeComponent implements OnInit, OnDestroy {
//   sub: Subscription = new Subscription();
//   async Test1(): Promise<string> {
//     // return 'test async function';
//     this.fetchData(5000);
//     let data: string = await this.fetchData(2);
//     return Promise.resolve(data);
//   }
//   fetchData(time: number): Promise<string> {
//     return new Promise((resolve) => {
//       setTimeout(() => {
//         console.log('again');
//         resolve('Data Loaded');
//       }, time);
//     });
//   }
//   async processArray(arr: number[]) {
//     for (let num of arr) {
//       await new Promise((resolve) => setTimeout(resolve, 2000)); // Wait 1 sec per item
//       console.log(num);
//     }
//   }
//   myObservable = new Observable((monkey) => {
//     setTimeout(() => monkey.next('🍌 Banana 1'), 1000); // Drop after 1 sec
//     setTimeout(() => monkey.next('🍌 Banana 2'), 2000); // Drop after 2 sec
//     setTimeout(() => monkey.next('🍌 Banana 3'), 3000); // Drop after 3 sec
//     setTimeout(() => monkey.complete(), 4000); // No more bananas
//   });
//   ngOnInit(): void {
//     const obs1 = this.myObservable.subscribe((value) => console.log(value));
//     // this.processArray([1,2,3,4])
//     // this.Test1().then((a) => {
//     //   console.log(a);
//     // });
//   }
//   ngOnDestroy(): void {
//     this.sub.unsubscribe();
//   }
// }

// const monkeyNames = new Observable<string[]>((observer) => {
//   observer.next(['George', 'Momo', 'Charlie']);
//   observer.complete();
// });

// // Use `map()` to change all monkey names
// monkeyNames.pipe(
//   map((names) => names.map((name) => `Monkey ${name}`)) // Add "Monkey" to the name
// ).subscribe({
//   next: (monkeys) => console.log(monkeys), // ["Monkey George", "Monkey Momo", "Monkey Charlie"]
// });

// const treeOneBananas = new Observable<string>((observer) => {
//   observer.next("🍌 Banana 1 from Tree 1");
//   observer.complete();
// });

// const treeTwoBananas = new Observable<string>((observer) => {
//   observer.next("🍌 Banana 1 from Tree 2");
//   observer.complete();
// });

// // Combine both tree's bananas into one stream
// merge(treeOneBananas, treeTwoBananas).subscribe({
//   next: (banana) => console.log(banana), // "🍌 Banana 1 from Tree 1" and "🍌 Banana 1 from Tree 2"
// });
