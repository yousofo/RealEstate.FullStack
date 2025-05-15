import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal, effect, computed } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AddPropertyService {
  httpClient = inject(HttpClient);

  type = signal<string>('house');
  ownership = signal<string>('full');
  location = signal<string>('');

  steps = [
    { name: 'Type', value: 'type' },
    { name: 'Ownership', value: 'ownership' },
    { name: 'Location', value: 'location' },
  ];

  currentStep = signal<number>(0);
  constructor() {}

  chooseType(type: any) {
    this.type.set(type);
  }

  chooseOwnership(ownership: any) {
    this.ownership.set(ownership);
  }

  chooseLocation(location: any) {
    this.location.set(location);
  }
}
