import { Component, ElementRef, inject, signal, viewChild } from '@angular/core';
import { TipComponent } from "../tip/tip.component";
import { LocationsService } from '../../../services/locations/locations.service';
import { ILocation } from '../../../types/locations';
import { NgClass, NgIf } from '@angular/common';
import { DebounceDirective } from '../../../directives/debounce.directive';

@Component({
  selector: 'app-search-location',
  imports: [TipComponent,NgClass,NgIf,DebounceDirective],
  templateUrl: './search-location.component.html',
  styleUrl: './search-location.component.scss'
})
export class SearchLocationComponent {
  selectedLocation: ILocation|null = null;
  locations=signal<ILocation[]>([])
  
  inputEl = viewChild<ElementRef<HTMLInputElement>>('locationInput');
  
  locationsService = inject(LocationsService);



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

  selectLocation(location: ILocation ) {
 
    console.log(this.inputEl());
    this.inputEl()!.nativeElement.value = location.display_name;
    this.selectedLocation = location;
  }

}
