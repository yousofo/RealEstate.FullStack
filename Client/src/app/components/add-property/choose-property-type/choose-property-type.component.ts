import { Component, inject, signal } from '@angular/core';
import { PropertiesService } from '../../../services/properties/properties.service';
import { AddPropertyService } from '../../../services/properties/add-property.service';
import { NgClass } from '@angular/common';
export interface IPropertyType {
  image: string;
  title: string;
  value: string;
}
@Component({
  selector: 'app-choose-property-type',
  imports: [NgClass],
  templateUrl: './choose-property-type.component.html',
  styleUrl: './choose-property-type.component.scss',
})
export class ChoosePropertyTypeComponent {
  propertyTypes = signal<IPropertyType[]>([
    { image: 't', title: 'House', value: 'house' },
    { image: 't', title: 'Apartment', value: 'apartment' },
    { image: '', title: 'Farm', value: 'farm' },
    { image: '', title: 'Land', value: 'land' },
    { image: '', title: 'Car', value: 'car' },
    { image: '', title: 'Prison', value: 'prison' },
    { image: '', title: 'Absolute Cinema', value: 'cinema' },
    { image: '', title: 'Studio', value: 'studio' },
    { image: '', title: 'Cabin', value: 'cabin' },
    { image: '', title: 'Warehouse', value: 'warehouse' },
  ]);
  propertiesService = inject(PropertiesService);
  addPropertyService = inject(AddPropertyService);

  ngOnInit() {
    this.propertiesService.getPropertyTypes().subscribe((e) => console.log(e));
  }

  selectPropertyType(propertyType: IPropertyType) {
    this.addPropertyService.chooseType(propertyType.value);
  }
}
