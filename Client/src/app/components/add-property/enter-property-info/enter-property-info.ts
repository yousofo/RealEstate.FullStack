import { NgClass, NgStyle } from '@angular/common';
import { Component, computed, inject, signal } from '@angular/core';
import { IListingType } from '../../../types/properties';
import { PropertiesService } from '../../../services/properties/properties.service';
import { AddPropertyService } from '../../../services/properties/add-property.service';
import { InputText } from 'primeng/inputtext';
import { ImageModule } from 'primeng/image';
import { Carousel } from 'primeng/carousel';
import { ButtonModule } from 'primeng/button';
import { Tag } from 'primeng/tag';
import { DividerModule } from 'primeng/divider';

@Component({
  selector: 'app-enter-property-info',
  imports: [
    NgClass,
    NgStyle,
    InputText,
    ImageModule,
    Carousel,
    ButtonModule,
    Tag,DividerModule
  ],
  templateUrl: './enter-property-info.html',
  styleUrl: './enter-property-info.scss',
})
export class EnterPropertyInfo {
  responsiveOptions: any[] | undefined;
  thumbnail = computed<string | null>(() =>
    this.addPropertyService.thumbnail() !== null
      ? URL.createObjectURL(this.addPropertyService.thumbnail()!)
      : null
  );
  images = computed(() => {
    if (this.addPropertyService.images() !== null) {
      return Object.values(this.addPropertyService.images()!).map(
        (image, index) => ({ index: index, image: URL.createObjectURL(image) })
      );
    }
    return [];
  });

  ngOnInit() {
    this.propertiesService.getPropertyListingTypes().subscribe((e) => {
      this.propertyListingTypes.set(e);
      this.toggleListingType(e[0]);
    });

    this.responsiveOptions = [
      {
        breakpoint: '1400px',
        numVisible: 2,
        numScroll: 1,
      },
      {
        breakpoint: '1199px',
        numVisible: 3,
        numScroll: 1,
      },
      {
        breakpoint: '767px',
        numVisible: 2,
        numScroll: 1,
      },
      {
        breakpoint: '575px',
        numVisible: 1,
        numScroll: 1,
      },
    ];
  }

  propertyListingTypes = signal<IListingType[]>([]);
  propertiesService = inject(PropertiesService);
  addPropertyService = inject(AddPropertyService);

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

  updateImages(newImages: FileList) {
    const newImageFiles = Object.values(newImages);
    this.addPropertyService.updateImages([
      ...this.addPropertyService.images()!,
      ...newImageFiles,
    ]);
  }
  removeImage(index: number) {
    this.addPropertyService.updateImages([
      ...this.addPropertyService.images()!.filter((_, i) => i !== index),
    ])
  }
}
