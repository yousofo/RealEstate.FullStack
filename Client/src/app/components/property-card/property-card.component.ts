import { Component, input } from '@angular/core';
import { IProperty } from '../../types/properties';
import { CurrencyPipe } from '@angular/common';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-property-card',
  standalone: true,
  imports: [CurrencyPipe],
  templateUrl: './property-card.component.html',
  styleUrl: './property-card.component.scss',
})
export class PropertyCardComponent {
  api = environment.apiUrl;
  data = input<IProperty>();

  formatLocation(location: IProperty['location']) {
    if (!location) return '';
    if (!location.regionName && !location.cityName) return location.countryName;

    if (!location.regionName)
      return `${location.cityName}, ${location.countryName}`;

    if (!location.cityName)
      return `${location.regionName}, ${location.countryName}`;

    return `${location.cityName}, ${location.regionName}, ${location.countryName}`;
  }
}
