import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoosePropertyGeolocationComponent } from './choose-property-geolocation.component';

describe('ChoosePropertyGeolocationComponent', () => {
  let component: ChoosePropertyGeolocationComponent;
  let fixture: ComponentFixture<ChoosePropertyGeolocationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChoosePropertyGeolocationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChoosePropertyGeolocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
