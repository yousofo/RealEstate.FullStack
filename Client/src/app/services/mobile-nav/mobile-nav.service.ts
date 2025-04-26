import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MobileNavService {
  isVisible = signal<boolean>(false)

  toggle() {
    this.isVisible.update(e=>!e)
  }
  

  constructor() { }
}
