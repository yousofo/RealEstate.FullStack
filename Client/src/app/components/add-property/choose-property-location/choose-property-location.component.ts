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
import { NgClass } from '@angular/common';
import { ILocation } from '../../../types/locations';
import { TipComponent } from "../../shared/tip/tip.component";
import { PropertySearchComponent } from "../../property-search/property-search.component";
import { SearchLocationComponent } from "../../shared/search-location/search-location.component";

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
    NgClass,
    TipComponent,
    PropertySearchComponent,
    SearchLocationComponent
],
  providers: [MessageService],
  templateUrl: './choose-property-location.component.html',
  styleUrl: './choose-property-location.component.scss',
})
export class ChoosePropertyLocationComponent {
 
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

  
  show() {
    this.messageService.add({
      severity: 'info',
      summary: 'Info',
      detail: 'Message Content',
      life: 3000,
    });
  }

 
}
