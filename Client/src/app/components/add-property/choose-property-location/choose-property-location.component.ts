import { Component, inject, signal } from '@angular/core';
import { DebounceClickDirective } from '../../../directives/debounce-click.directive';
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
 
interface Country {
  name: string;
  code: string;
}
@Component({
  selector: 'app-choose-property-location',
  imports: [
    DebounceClickDirective,
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

  places = signal<IPlace[]>([]);

  ngOnInit() {
    this.httpClient
      .get<Country[]>(`${environment}/api/countries`)
      .subscribe({
        next: (data) => {
          this.countries = data;
        },
        error: (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'service unavailable, please try again later',
            life: 2000,
          })
        },
      });
      
    
  }

  onClick(query: string) {
    this.httpClient
      .get<IPlace[]>(
        `/locations/v1/search?apikey=${environment.placesApiKey}&q=${query}`
      )
      .subscribe({
        next: (data) => {
          console.log(data);
          this.places.set(data);
        },
        error: (error) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: 'sorry, api quota ran out :(, will use mock data for now',
            life: 2000,
          })
          setTimeout(() => {
            this.addPropertyService.chooseLocation('Sydney');
          },2000)
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
}
