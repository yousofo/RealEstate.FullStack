import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoosePropertyOwnershipTypeComponent } from './choose-property-ownership-type.component';

describe('ChoosePropertyOwnershipTypeComponent', () => {
  let component: ChoosePropertyOwnershipTypeComponent;
  let fixture: ComponentFixture<ChoosePropertyOwnershipTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChoosePropertyOwnershipTypeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChoosePropertyOwnershipTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
