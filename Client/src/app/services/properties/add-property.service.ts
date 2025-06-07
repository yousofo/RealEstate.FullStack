import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal, effect, computed } from '@angular/core';
import { finalize } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ILocationDTO } from '../../types/locations';

interface IGeoLocation {
  latitude: number;
  longitude: number;
}
export interface IPropertyInfo {
  title: string;
  price: number;
  description: string;
  addressDescription: string;
}

@Injectable({
  providedIn: 'root',
})
export class AddPropertyService {
  httpClient = inject(HttpClient);

  cateogryId = signal<number>(1);
  info = signal<IPropertyInfo>({
    title: '',
    price: 0,
    description: '',
    addressDescription: '',
  });
  // ownership = signal<string>('full');
  location = signal<ILocationDTO | null>(null);
  geoLocation = signal<IGeoLocation | null>(null);
  listingTypesIds = signal<number[]>([]);
  thumbnail = signal<File | null>(null);
  images = signal<File[]>([]);
  organizationId = signal<number | null>(null);

  steps = [
    { name: 'Category', value: 'category' },
    { name: 'Listing Type', value: 'listingType' },
    { name: 'Location', value: 'location' },
    { name: 'Geo Location', value: 'geoLocation' },
    { name: 'Info', value: 'info' },
  ];

  currentStep = signal<number>(0);
  constructor() {}

  chooseCategory(id: number) {
    this.cateogryId.set(id);
  }

  toggleListingType(id: number) {
    if (this.listingTypesIds().includes(id))
      this.listingTypesIds.update((types) =>
        types.filter((type) => type !== id)
      );
    else this.listingTypesIds.update((types) => [...types, id]);
  }

  // chooseOwnership(ownership: any) {
  //   this.ownership.set(ownership);
  // }

  chooseLocation(location: any) {
    this.location.set(location);
  }

  selectLocation(location: ILocationDTO) {
    this.location.set(location);
  }

  selectGeoLocation(location: IGeoLocation) {
    this.geoLocation.set(location);
  }

  updateInfo(info: IPropertyInfo) {
    this.info.set(info);
  }

  updateThumbnail(thumbnail: File) {
    this.thumbnail.set(thumbnail);
  }

  updateImages(images: File[]) {
    this.images.set(images);
  }

  createProperty() {
    let formData = new FormData();

    formData.append('title', this.info().title);
    formData.append('price', this.info().price.toString());
    formData.append('description', this.info().description);

    Object.values(this.listingTypesIds()).forEach((id) =>
      formData.append('listingTypesIds', id.toString())
    );

    Object.values(this.images()!).forEach((image) =>
      formData.append('images', image)
    );

    formData.append('thumbnail', this.thumbnail()!);
    formData.append('organizationId', this.organizationId()?.toString() ?? '');
    formData.append('categoryId', this.cateogryId().toString());
    formData.append('countryName', this.location()!.countryName!);
    formData.append('regionName', this.location()!.regionName!);
    formData.append('cityName', this.location()!.cityName!);
    formData.append('addressDescription', this.info().addressDescription);
    formData.append('latitude', this.geoLocation()?.latitude.toString() ?? '');
    formData.append(
      'longitude',
      this.geoLocation()?.longitude.toString() ?? ''
    );

    return this.httpClient
      .post(environment.apiUrl + '/api/properties', formData)
      .pipe(finalize(() => console.log('Property added')));
  }
}
