import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoosePropertyTypeComponent } from './choose-property-type.component';

describe('ChoosePropertyTypeComponent', () => {
  let component: ChoosePropertyTypeComponent;
  let fixture: ComponentFixture<ChoosePropertyTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChoosePropertyTypeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChoosePropertyTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
