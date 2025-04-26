import { inject, Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  _isVisible = signal<boolean>(false);


  get isVisible(): boolean {
    return this._isVisible();
  }
  set isVisible(value: boolean) {
    console.log('value');
    this._isVisible.set(value);
  }
  toggle() {
    this._isVisible.update((e) => !e);
  }

  hide() {
    this._isVisible.set(false);
  }

  constructor() {}
}
