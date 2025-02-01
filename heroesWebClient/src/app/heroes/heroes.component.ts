import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { ApisService } from '../services/apis.service';
import { Router } from '@angular/router';
import { SharedDataService } from '../services/shared-data.service';

@Component({
  selector: 'app-heroes',
  standalone: false,

  templateUrl: './heroes.component.html',
  styleUrl: './heroes.component.css',
})
export class heroesComponent implements OnInit {
  http = inject(ApisService);
  route = inject(Router);
  dataService = inject(SharedDataService);
  heroes: any = [
    // { id: 1, firstName: 'Superman' },
    // { id: 2, firstName: 'Batman' },
  ];
  ngOnInit(): void {
    let v1: any = null;
    this.http.getHeroes().subscribe({
      next: function(this: heroesComponent, value: any) {
        console.log(value);
        this.heroes= value.body;
      }.bind(this),  // Bind 'this' to the component class

      error: function(err:any ) {  // Bind 'this' for error callback
        console.error('Error:', err);  // Handle errors

      }.bind(this),

      complete: function() {  // Bind 'this' for complete callback
        console.log('Request complete');  // Handle completion
      }.bind(this)
    });



  }
  viewDetails(hero: any) {
    // console.log(hero);
    this.dataService.setData('hero', hero);
    this.route.navigate(['/heroesDetails']);
  }
}
