import { Component, OnInit } from '@angular/core';
import {
  catchError,
  combineLatest,
  concat,
  forkJoin,
  interval,
  map,
  merge,
  mergeMap,
  Observable,
  of,
  retry,
  switchMap,
  take,
  throwError,
  timeout,
  zip,
} from 'rxjs';
import { AsyncSubject } from 'rxjs';

@Component({
  selector: 'customComp',
  standalone: false,
  template: ` <div>hello cstuom comp</div>`,
  styles: ``,
})
export class customComp implements OnInit {
  myObservable = new Observable((observer) => {
    observer.next('Hello');
    observer.next('RxJS');
    observer.complete(); // Marks as completed
    observer.next(new Error('something terrible happened'));
  });

  asyncSubject = new AsyncSubject();

  ngOnInit(): void {
    // of(1, 2, 3)
    //   .pipe(
    //     map((x) => {
    //       console.error(x);
    //       return x * 10;
    //     })
    //   )
    //   .subscribe(console.log);
    // const p = of('A', 'B')
    //   .pipe(mergeMap((val) => interval(1000).pipe(map((i) => val + i))))
    //   .subscribe(console.log);
    // setTimeout(() => p.unsubscribe(), 1000);

    // of(1, 2, 3, 4, 5).pipe(take(3)).subscribe(console.log);

    const obs1 = of(1, 2, 3);
    const obs2 = of('A', 'B', 'C', 'D');
    const obs3 = of('X', 'Y', 'Z', 'F');
    const obs4 = throwError(() => new Error('Something went wrong!')).pipe(
      catchError((e) => {
        console.error('Error caught:', e);
        return of([e]);
      })
    );

    // combineLatest([obs1, obs2, obs3]).subscribe(console.log);
    // zip(obs1, obs2, obs3).subscribe(console.log);
    const obs5 = throwError(() => new Error('Something went wrong!')).pipe(
      retry(2)
    ); // Retries 2 times before failing

    // concat(obs1, obs2).subscribe(console.log);

    merge(obs1, obs2).subscribe(console.log);
    // forkJoin([obs1, obs2, obs3])
    //   .pipe(
    //     catchError((error) => {
    //       console.error('Error caught:', error);

    //       return of(['Fallback Value 1111']); // Provides a fallback to avoid breaking
    //     })
    //   )
    //   .subscribe(
    //     (result) => console.log('Result:', result),
    //     (error) => console.log('Error:', error) // Won't be executed due to catchError
    //   );

    forkJoin([obs1, obs2, obs3, obs4])
      .pipe(catchError((err) => of('from forkjoin Fallback Value')))
      .subscribe(console.log);

    // throwError(() => new Error('Something went wrong!'))
    //   .pipe(catchError((err) => of('Fallback Value')))
    //   .subscribe(console.log);

    // of('A', 'B').pipe(switchMap(val => of(val + '1'))).subscribe(console.error);

    this.asyncSubject.subscribe((value) => console.log('Subscriber:', value));

    this.asyncSubject.next('Value 1');
    this.asyncSubject.next('Value 2');
    this.asyncSubject.next('Value 3');

    this.asyncSubject.complete();
    this.asyncSubject.next('Value 6');

    this.myObservable.subscribe(
      (value) => console.log(value),
      (error) => {
        console.log('errpr');
        console.log(error);
      }
    );
  }
}
