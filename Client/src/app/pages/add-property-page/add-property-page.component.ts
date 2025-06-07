import {
  Component,
  inject,
  signal,
  CUSTOM_ELEMENTS_SCHEMA,
  effect,
  viewChild,
  ElementRef,
} from '@angular/core';
import { ProgressBar } from 'primeng/progressbar';
import { SwiperContainer, SwiperSlide } from 'swiper/element';
import { ChoosePropertyCategoryComponent } from '../../components/add-property/choose-property-category/choose-property-category';
import { AddPropertyService } from '../../services/properties/add-property.service';
import { ChoosePropertyOwnershipTypeComponent } from '../../components/add-property/choose-property-ownership-type/choose-property-ownership-type.component';
import { Button } from 'primeng/button';
import { ChoosePropertyLocationComponent } from '../../components/add-property/choose-property-location/choose-property-location.component';
import { ChoosePropertyGeolocationComponent } from '../../components/add-property/choose-property-geolocation/choose-property-geolocation.component';
import { ChoosePropertyListingTypes } from "../../components/add-property/choose-property-listing-types/choose-property-listing-types";
import { EnterPropertyInfo } from "../../components/add-property/enter-property-info/enter-property-info";
import { MessageService } from 'primeng/api';
export interface IPropertyType {
  image: string | null;
  title: string;
}

@Component({
  selector: 'app-add-property-page',
  imports: [
    ProgressBar,
    ChoosePropertyCategoryComponent,
    ChoosePropertyOwnershipTypeComponent,
    Button,
    ChoosePropertyLocationComponent,
    ChoosePropertyGeolocationComponent,
    ChoosePropertyListingTypes,
    EnterPropertyInfo,
],
  templateUrl: './add-property-page.component.html',
  styleUrl: './add-property-page.component.scss',
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AddPropertyPageComponent {
  // currentStep=signal(0);
  swiperElment = viewChild<ElementRef<SwiperContainer>>('swiperContainer');

  addPropertyService = inject(AddPropertyService);
  messageService = inject(MessageService);

  constructor() {
    this.addPropertyService.currentStep.set(0);
    effect(() => {
      this.swiperElment()?.nativeElement.swiper?.slideTo(
        this.addPropertyService.currentStep()
      );
    });
  }

  slideNext() {
    if (this.addPropertyService.currentStep() >= this.addPropertyService.steps.length-1) {
      this.addPropertyService.createProperty().subscribe({
        next: (res) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: 'Property created successfully',
          })
        },
      })
    };
    this.addPropertyService.currentStep.update((s) => s + 1);
  }
  slidePrev() {
    if (this.addPropertyService.currentStep() <= 0) return;
    this.addPropertyService.currentStep.update((s) => s - 1);
  }
}
