import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SharedDataService } from '../services/shared-data.service';

@Component({
  selector: 'app-heroes-detail',
  standalone: false,

  templateUrl: './heroes-detail.component.html',
  styleUrl: './heroes-detail.component.css',
})
export class HeroesDetailComponent {
  data = inject(SharedDataService);
  selectedUser: any;
  constructor() {
    // this.selectedUser = this.route.snapshot.paramMap.get('id');
    // console.log(this.route.snapshot.queryParamMap.get('id'));
    //  console.log(this.selectedUser);
    this.data.getData('hero').subscribe((data: any) => {
      this.selectedUser = data;
    } );
  }
}
