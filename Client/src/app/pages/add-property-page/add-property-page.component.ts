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
import { ChoosePropertyTypeComponent } from '../../components/add-property/choose-property-type/choose-property-type.component';
import { AddPropertyService } from '../../services/properties/add-property.service';
import { ChoosePropertyOwnershipTypeComponent } from '../../components/add-property/choose-property-ownership-type/choose-property-ownership-type.component';
import { Button } from 'primeng/button';
import { ChoosePropertyLocationComponent } from "../../components/add-property/choose-property-location/choose-property-location.component";
import { ChoosePropertyGeolocationComponent } from "../../components/add-property/choose-property-geolocation/choose-property-geolocation.component";
export interface IPropertyType {
  image: string | null;
  title: string;
}

@Component({
  selector: 'app-add-property-page',
  imports: [
    ProgressBar,
    ChoosePropertyTypeComponent,
    ChoosePropertyOwnershipTypeComponent,
    Button,
    ChoosePropertyLocationComponent,
    ChoosePropertyGeolocationComponent
],
  templateUrl: './add-property-page.component.html',
  styleUrl: './add-property-page.component.scss',
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AddPropertyPageComponent {
  // currentStep=signal(0);
  swiperElment = viewChild<ElementRef<SwiperContainer>>('swiperContainer');
  addPropertyService = inject(AddPropertyService);

  constructor() {
    effect(() => {
      this.swiperElment()?.nativeElement.swiper?.slideTo(
        this.addPropertyService.currentStep()
      );
    });
  }

  slideNext() {
    if (this.addPropertyService.currentStep() >= 3) return;
    this.addPropertyService.currentStep.update((s) => s + 1);
  }
  slidePrev() {
    if (this.addPropertyService.currentStep() <= 0) return;
    this.addPropertyService.currentStep.update((s) => s - 1);
  }
}
