import { NgClass } from '@angular/common';
import { Component, computed, inject, signal } from '@angular/core';
import { IListingType } from '../../../types/properties';
import { PropertiesService } from '../../../services/properties/properties.service';
import { AddPropertyService } from '../../../services/properties/add-property.service';
import { InputText } from 'primeng/inputtext';
import { ImageModule } from 'primeng/image';

@Component({
  selector: 'app-enter-property-info',
  imports: [NgClass, InputText, ImageModule],
  templateUrl: './enter-property-info.html',
  styleUrl: './enter-property-info.scss',
})
export class EnterPropertyInfo {
  thumbnail = computed<string|null>(() =>
    this.addPropertyService.thumbnail() !== null
      ? URL.createObjectURL(this.addPropertyService.thumbnail()!)
      : null
  );

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
  updateTitle(title: string) {
    this.addPropertyService.updateInfo({
      ...this.addPropertyService.info(),
      title,
    });
  }

  updatePrice(price: string) {
    this.addPropertyService.updateInfo({
      ...this.addPropertyService.info(),
      price: Number(price),
    });
  }

  updateDescription(description: string) {
    this.addPropertyService.updateInfo({
      ...this.addPropertyService.info(),
      description,
    });
  }
  updateAddressDescription(addressDescription: string) {
    this.addPropertyService.updateInfo({
      ...this.addPropertyService.info(),
      addressDescription,
    });
  }
  updateThumbnail(thumbnail: File) {
    console.log(thumbnail);
    this.addPropertyService.updateThumbnail(thumbnail);
  }
}
