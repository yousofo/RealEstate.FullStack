import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoosePropertyListingTypes } from './choose-property-listing-types';

describe('ChoosePropertyListingTypes', () => {
  let component: ChoosePropertyListingTypes;
  let fixture: ComponentFixture<ChoosePropertyListingTypes>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChoosePropertyListingTypes]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChoosePropertyListingTypes);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
