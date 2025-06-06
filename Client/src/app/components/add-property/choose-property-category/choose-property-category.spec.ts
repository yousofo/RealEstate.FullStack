import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoosePropertyCategoryComponent } from './choose-property-category';

describe('ChoosePropertyTypeComponent', () => {
  let component: ChoosePropertyCategoryComponent;
  let fixture: ComponentFixture<ChoosePropertyCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChoosePropertyCategoryComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(ChoosePropertyCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
