import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { ILocation  } from '../../types/locations';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class LocationsService {
  httpClient = inject(HttpClient);
  locations = signal<ILocation>({} as ILocation);

  async getLocations(textQuery: string) {
    const locations = await fetch(
      `${environment.apiUrl}/api/locations/${textQuery}`
    );
    if (!locations.ok) {
      throw new Error('Failed to fetch locations');
    }
    return await locations.json();
  }
  // getLocationsPage(searchRequest: IPaginatedSearchRequest = this.pageConfig): Observable<IPaginatedResponse<IProperty>> {
  //   var placesService = inject(PlacesService);
  //    this.pageConfig = searchRequest;

  //   // this.checkLoading();
  //   // console.log(`${this.urls.getPage}?`);
  //   return this.httpClient
  //     .get<IPaginatedResponse<IProperty>>(
  //       `${this.urls.getPage}?` +
  //         `pageNumber=${this.pageConfig?.pageNumber ?? 1}&` +
  //         `pageSize=${this.pageConfig?.pageSize ?? 10}&` +
  //         `searchTerm=${this.pageConfig?.searchTerm ?? ''}&` +
  //         `orderBy=${this.pageConfig?.orderBy ?? 'id'}`
  //     )
  //     .pipe(
  //       finalize(() => {
  //         console.log('finalized from base get page');
  //       })
  //     );
  // }
}
