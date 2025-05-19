import { Component, input } from '@angular/core';
import { IProperty } from '../../types/properties';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-property-card',
  standalone: true,
  imports:[CurrencyPipe],
  templateUrl: './property-card.component.html',
  styleUrl: './property-card.component.scss'
})
export class PropertyCardComponent {
  data = input<IProperty>()
}
