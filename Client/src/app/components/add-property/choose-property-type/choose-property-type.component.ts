import { Component, inject, signal } from '@angular/core';
import { PropertiesService } from '../../../services/properties/properties.service';
import { AddPropertyService } from '../../../services/properties/add-property.service';
import { NgClass } from '@angular/common';
import { ICategory } from '../../../types/locations';
 
@Component({
  selector: 'app-choose-property-type',
  imports: [NgClass],
  templateUrl: './choose-property-type.component.html',
  styleUrl: './choose-property-type.component.scss',
})
export class ChoosePropertyTypeComponent {
  propertyTypes = signal<ICategory[]>([]);
  propertiesService = inject(PropertiesService);
  addPropertyService = inject(AddPropertyService);

  ngOnInit() {
    this.propertiesService
      .getPropertyTypes()
      .subscribe((e) => this.propertyTypes.set(e));
  }

  selectPropertyType(propertyType: ICategory) {
    this.addPropertyService.chooseType(propertyType.id);
  }
}
