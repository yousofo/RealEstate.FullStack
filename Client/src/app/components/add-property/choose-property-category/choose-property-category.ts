import { Component, inject, signal } from '@angular/core';
import { PropertiesService } from '../../../services/properties/properties.service';
import { AddPropertyService } from '../../../services/properties/add-property.service';
import { NgClass } from '@angular/common';
import { ICategory } from '../../../types/properties';
 
@Component({
  selector: 'app-choose-property-category',
  imports: [NgClass],
  templateUrl: './choose-property-category.html',
  styleUrl: './choose-property-category.scss',
})
export class ChoosePropertyCategoryComponent {
  propertyCategories = signal<ICategory[]>([]);
  propertiesService = inject(PropertiesService);
  addPropertyService = inject(AddPropertyService);

  ngOnInit() {
    this.propertiesService
      .getPropertyCategories()
      .subscribe((e) => this.propertyCategories.set(e));
  }

  selectPropertyCategory(propertyType: ICategory) {
    this.addPropertyService.chooseCategory(propertyType.id);
  }
}
