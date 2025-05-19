import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  public loading= signal(false);
  constructor() { }
 
  stop(){
    this.loading.set(false);
  }
  start(){
    this.loading.set(true);
  }
}
