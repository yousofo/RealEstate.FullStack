import { Component, input } from '@angular/core';
import { IProperty } from '../../types/properties';

@Component({
  selector: 'app-property-card',
  standalone: true,
  templateUrl: './property-card.component.html',
  styleUrl: './property-card.component.scss'
})
export class PropertyCardComponent {
  data = input<IProperty>()
}
