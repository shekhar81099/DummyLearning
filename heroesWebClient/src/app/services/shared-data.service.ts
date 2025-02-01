import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SharedDataService {

  constructor() {}

  setData(key: string, value: any) {
    sessionStorage.setItem(key , JSON.stringify(value))

  }

  getData(key: string) {
    const storedUser = sessionStorage.getItem(key);
    return  storedUser ? JSON.parse(storedUser) : null;

  }
}
