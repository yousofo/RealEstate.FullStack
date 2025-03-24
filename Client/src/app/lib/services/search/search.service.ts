import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  private _input = signal('');
  get input(): string {
    return this._input();
  }
  set input(value: string) {
    this._input.set(value);
  }
  constructor() {}
}
