import { Component, inject, signal } from '@angular/core';
import { DebounceDirective } from '../../../directives/debounce.directive';
import { InputText, InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputGroup } from 'primeng/inputgroup';
import { ListboxModule } from 'primeng/listbox';
import { FormsModule, NgModel } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { IPlace } from './places-response-type';
import { MessageService } from 'primeng/api';
import { AddPropertyService } from '../../../services/properties/add-property.service';
import { IPaginatedResponse } from '../../../services/types/IPaginatedResponse';

interface Country {
  name: string;
  code: string;
}
interface ILocation {
  countryId: number;
  countryName: string;
  regionId: number;
  regionName: string;
  cityId: number;
  cityName: string;
}
@Component({
  selector: 'app-choose-property-location',
  imports: [
    DebounceDirective,
    InputText,
    InputGroup,
    InputGroupAddonModule,
    InputTextModule,
    ButtonModule,
    ListboxModule,
    FormsModule,
  ],
  providers: [MessageService],
  templateUrl: './choose-property-location.component.html',
  styleUrl: './choose-property-location.component.scss',
})
export class ChoosePropertyLocationComponent {
  countries!: Country[];

  selectedCountry!: Country;

  httpClient = inject(HttpClient);
  messageService = inject(MessageService);
  addPropertyService = inject(AddPropertyService);

  locations = signal<ILocation[]>([]);

  ngOnInit() {
    // this.httpClient
    //   .get<Country[]>(`${environment}/api/countries`)
    //   .subscribe({
    //     next: (data) => {
    //       this.countries = data;
    //     },
    //     error: (error) => {
    //       this.messageService.add({
    //         severity: 'error',
    //         summary: 'Error',
    //         detail: 'service unavailable, please try again later',
    //         life: 2000,
    //       })
    //     },
    //   });
  }

  getLocations(query: string) {
    console.log(query);
    this.httpClient
      .get<IPaginatedResponse<ILocation>>(
        // `/locations/v1/search?apikey=${environment.placesApiKey}&q=${query}`
        `${environment.apiUrl}/api/LocationsView/page?SearchTerm=${query}`
      )
      .subscribe({
        next: (data) => {
          console.log(data);
          this.locations.set(data.items);
        },
        error: (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'sorry, api quota ran out :(, will use mock data for now',
            life: 2000,
          });
          setTimeout(() => {
            this.addPropertyService.chooseLocation('Sydney');
          }, 2000);
        },
      });
  }
  show() {
    this.messageService.add({
      severity: 'info',
      summary: 'Info',
      detail: 'Message Content',
      life: 3000,
    });
  }

  getLocationText({ cityName, regionName, countryName }: ILocation) {
    if (cityName && regionName) {
      return `${cityName}, ${regionName}, ${countryName}`;
    }

    if (cityName) {
      return `${cityName}, ${countryName}`;
    }

    if (regionName) {
      return `${regionName}, ${countryName}`;
    }

    return countryName;
  }
}
