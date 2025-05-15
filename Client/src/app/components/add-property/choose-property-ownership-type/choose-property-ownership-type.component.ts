import { Component, inject, signal } from '@angular/core';
import { PropertiesService } from '../../../services/properties/properties.service';
import { AddPropertyService } from '../../../services/properties/add-property.service';
import { NgClass } from '@angular/common';
export interface IOwnership {
  image: string;
  title: string;
  value: string;
}
@Component({
  selector: 'app-choose-property-ownership-type',
  imports: [NgClass],
  templateUrl: './choose-property-ownership-type.component.html',
  styleUrl: './choose-property-ownership-type.component.scss',
})
export class ChoosePropertyOwnershipTypeComponent {
  propertyTypes = signal<IOwnership[]>([
    { image: '', title: 'Full Ownership', value: 'full' },
    { image: 't', title: 'A Room', value: 'room' },
  ]);
  propertiesService = inject(PropertiesService);
  addPropertyService = inject(AddPropertyService);

  ngOnInit() {
    this.propertiesService.getPropertyTypes().subscribe((e) => console.log(e));
  }

  selectPropertyType(propertyType: IOwnership) {
 
    this.addPropertyService.chooseOwnership(propertyType.value);
  }
}
