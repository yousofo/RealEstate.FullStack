import { Component, ElementRef, inject ,signal, viewChild} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Select } from 'primeng/select';
import { LocationsService } from '../../services/locations/locations.service';
import { InputTextModule } from 'primeng/inputtext';
import { TipComponent } from '../shared/tip/tip.component';
import { DebounceDirective } from '../../directives/debounce.directive';
import { ILocation } from '../../types/locations';
import { NgClass, NgIf } from '@angular/common';

@Component({
  selector: 'app-property-search',
  imports: [Select, FormsModule, InputTextModule, TipComponent,DebounceDirective,NgIf,NgClass],
  templateUrl: './property-search.component.html',
  styleUrl: './property-search.component.scss',
})
export class PropertySearchComponent {
  locationsService = inject(LocationsService);
  inputEl = viewChild<ElementRef<HTMLInputElement>>('locationInput');
  locations=signal<ILocation[]>([])
  selectedLocation: ILocation|null = null;

  selectedContractType  = { name: 'Buy', code: 'BUY', ar: 'شراء' };
  contractTypes: any[] = [
    { name: 'Rent', code: 'RENT', ar: 'إيجار' },
    { name: 'Buy', code: 'BUY', ar: 'شراء' },
  ];

  selectedPropertyType = { name: 'Apartment', code: 'APT' };
  propertyTypes: any[] = [
    { name: 'Apartment', code: 'APT' },
    { name: 'House', code: 'HSE' },
    { name: 'Cabin', code: 'CBN' },
  ];

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

  selectLocation(location: ILocation,event: Event) {
    event.stopPropagation();
    event.preventDefault();
    console.log(this.inputEl());
    this.inputEl()!.nativeElement.value = location.display_name;
    this.selectedLocation = location;
  }
}
