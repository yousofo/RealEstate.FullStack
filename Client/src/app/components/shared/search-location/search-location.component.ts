import {
  Component,
  ElementRef,
  inject,
  signal,
  viewChild,
} from '@angular/core';
import { TipComponent } from '../tip/tip.component';
import { LocationsService } from '../../../services/locations/locations.service';
import { ILocation } from '../../../types/locations';
import { NgClass, NgIf } from '@angular/common';
import { DebounceDirective } from '../../../directives/debounce.directive';
import { AddPropertyService } from '../../../services/properties/add-property.service';
import { PropertiesService } from '../../../services/properties/properties.service';

@Component({
  selector: 'app-search-location',
  imports: [TipComponent, NgClass, NgIf, DebounceDirective],
  templateUrl: './search-location.component.html',
  styleUrl: './search-location.component.scss',
})
export class SearchLocationComponent {
  locations = signal<ILocation[]>([]);

  inputEl = viewChild<ElementRef<HTMLInputElement>>('locationInput');

  locationsService = inject(LocationsService);
  addPropertyService = inject(AddPropertyService);
  propertiesService = inject(PropertiesService);

  search(query: string) {
    this.locationsService
      .getLocations(query)
      .then((locations) => {
        this.locations.set(locations);
        console.log('Locations fetched:', locations);
      })
      .catch((error) => {
        console.error('Error fetching locations:', error);
      });
  }

  selectLocation(location: ILocation) {
    console.log(this.inputEl());
    this.inputEl()!.nativeElement.value = location.display_name;
    const address = location.address;
    this.addPropertyService.selectLocation({
      cityName: this.getCity(address),
      regionName: this.getRegion(address),
      countryName: address.country,
    });
    console.log(this.addPropertyService.location());
    if (window.location.pathname !== '/add-property') {
      this.propertiesService.getPageByLocation(undefined, this.addPropertyService.location()!).subscribe();
    }
  }

  getCity(address: ILocation['address']) {
    if (address['city']) return address['city'];
    if (address['county']) return address['county'];
    if (address['village']) return address['village'];
    return '';
  }

  getRegion(address: ILocation['address']) {
    if (address['region']) return address['region'];
    if (address['state']) return address['state'];
    if (address['area']) return address['area'];
    return '';
  }
}
