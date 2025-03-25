import { inject, Injectable, Signal, signal } from '@angular/core';
import { IProperty } from '../../types/properties';
import { HttpClient } from '@angular/common/http';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root',
})
export class PropertiesService {
  private _properties = signal<IProperty[]>([]);

  httpClient = inject(HttpClient);
  // messageService = inject(MessageService);

  get properties(): Signal<IProperty[]> {
    return this._properties.asReadonly();
  }
  // set properties(value: IProperty[]) {
  //   this._properties.set(value);
  // }
  ngOnInit(): void {
    this.httpClient.get<IProperty[]>('/api/properties').subscribe({
      next: (properties) => {
        console.log(properties);
        this._properties.set(properties);
      },
      error: (error) => {
        console.error(error);
      },
    });
  }

  add(property: IProperty) {
    let newPropertyIx = 0;

    this._properties.update((e) => {
      newPropertyIx = e.push(property);
      return e;
    });

    this.httpClient.post('/api/properties', property).subscribe({
      next: () => {
        console.log('Property added');
      },
      error: (error) => {
        console.error(error);
        this._properties.update((e) => {
          e.splice(newPropertyIx, 1);
          return e;
        });
        // this.messageService.add({
        //   severity: 'error',
        //   summary: 'Error',
        //   detail: 'Failed to add property',
        // });
      },
    });
  }
  delete(property: IProperty) {
    let deleteObservable = this.httpClient.delete(`/api/properties/${property.id}`);

    deleteObservable.subscribe({
      next: () => {
        console.log('Property deleted');
      },
      error: (error) => {
        console.error(error);
        // this.messageService.add({
        //   severity: 'error',
        //   summary: 'Error',
        //   detail: 'Failed to delete property',
        // });
      },
    })

    return deleteObservable;
  }
  filter(predicate: (property: IProperty) => boolean) {
     this._properties.update(e=>e.filter(predicate));
  }
}
