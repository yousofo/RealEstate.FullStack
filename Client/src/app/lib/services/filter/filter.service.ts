import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FilterService {
  private _searchInput = signal('');
  get searchInput(): string { return this._searchInput(); }
  set searchInput(value: string) { this._searchInput.set(value); }
  
  constructor() { }
}
