import { NgClass } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { PropertiesService } from '../../../services/properties/properties.service';
import { AddPropertyService } from '../../../services/properties/add-property.service';
import { IListingType } from '../../../types/properties';

@Component({
  selector: 'app-choose-property-listing-types',
  imports: [NgClass],
  templateUrl: './choose-property-listing-types.html',
  styleUrl: './choose-property-listing-types.scss',
})
export class ChoosePropertyListingTypes {
  propertyListingTypes = signal<IListingType[]>([]);
  propertiesService = inject(PropertiesService);
  addPropertyService = inject(AddPropertyService);

  ngOnInit() {
    this.propertiesService.getPropertyListingTypes().subscribe((e) => {
      this.propertyListingTypes.set(e);
      this.toggleListingType(e[0]);
    });
  }

  toggleListingType(propertyType: IListingType) {
    this.addPropertyService.toggleListingType(propertyType.id);
  }
}
