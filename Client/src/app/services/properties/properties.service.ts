import { inject, Injectable, Signal, signal } from '@angular/core';
import { IListingType, IProperty } from '../../types/properties';
import { HttpClient } from '@angular/common/http';
import { MessageService } from 'primeng/api';
import { environment } from '../../../environments/environment';
import { finalize, Observable } from 'rxjs';
import BaseService from '../types/BaseService';
import { IPaginatedResponse } from '../types/IPaginatedResponse';
import IPaginatedSearchRequest from '../types/IPaginatedSearchRequest';
import { LocationsService } from '../locations/locations.service';
import { ICategory } from '../../types/properties';
import { ILocationDTO, ILocationRDTO } from '../../types/locations';
@Injectable({
  providedIn: 'root',
})
export class PropertiesService extends BaseService<IProperty> {
  private _properties = signal<IProperty[]>([]);
  override apiRoute = 'api/properties';
  // messageService = inject(MessageService);

  get properties(): Signal<IProperty[]> {
    return this._properties.asReadonly();
  }
  /**
   *
   */

  // set properties(value: IProperty[]) {
  //   this._properties.set(value);
  // }
  loadData() {
    this.httpClient
      .get<IProperty[]>(environment.apiUrl + '/api/properties', {
        withCredentials: true,
      })
      .subscribe({
        next: (properties) => {
          console.log(properties);
          this._properties.set(properties);
        },
        error: (error) => {
          console.error(error);
        },
        complete: () => {
          console.error('done');
        },
      });
  }

  getPropertyCategories() {
    return this.httpClient
      .get<ICategory[]>(environment.apiUrl + '/api/categories')
      .pipe(finalize(() => console.log('getPropertyTypes finalized')));
  }
  getPropertyListingTypes() {
    return this.httpClient
      .get<IListingType[]>(environment.apiUrl + '/api/listingtypes')
      .pipe(finalize(() => console.log('getPropertyTypes finalized')));
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
    let deleteObservable = this.httpClient.delete(
      `/api/properties/${property.id}`
    );

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
    });

    return deleteObservable;
  }
  filter(predicate: (property: IProperty) => boolean) {
    this._properties.update((e) => e.filter(predicate));
  }


  getPageByLocation(searchRequest: IPaginatedSearchRequest = this.pageConfig, location:ILocationDTO|null=null)  {
      this.pageConfig = searchRequest;
  
      // this.checkLoading();
      // console.log(`${this.urls.getPage}?`);
      return this.httpClient
        .get<IPaginatedResponse<IProperty>>(
          `${this.urls.getPage}/location?` +
            `pageNumber=${this.pageConfig?.pageNumber ?? 1}&` +
            `pageSize=${this.pageConfig?.pageSize ?? 10}&` +
            `searchTerm=${this.pageConfig?.searchTerm ?? ''}&` +
            `orderBy=${this.pageConfig?.orderBy ?? 'id'}&`+
            `CountryName=${location?.countryName ?? ''}&`+
            `RegionName=${location?.regionName ?? ''}&`+
            `CityName=${location?.cityName ?? ''}`
        )
        .pipe(
          finalize(() => {
            console.log('finalized from base get page');
          })
        );
    }
}
