import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal, effect, computed } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AddPropertyService {
  httpClient = inject(HttpClient);

  type = signal<number>(1);
  ownership = signal<string>('full');
  location = signal<string>('');

  steps = [
    { name: 'Type', value: 'type' },
    { name: 'Ownership', value: 'ownership' },
    { name: 'Location', value: 'location' },
  ];

  currentStep = signal<number>(0);
  constructor() {}

  chooseType(id: number) {
    this.type.set(id);
  }

  chooseOwnership(ownership: any) {
    this.ownership.set(ownership);
  }

  chooseLocation(location: any) {
    this.location.set(location);
  }
}
