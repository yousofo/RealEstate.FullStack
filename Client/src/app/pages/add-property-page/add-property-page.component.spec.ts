import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPropertyPageComponent } from './add-property-page.component';

describe('AddPropertyPageComponent', () => {
  let component: AddPropertyPageComponent;
  let fixture: ComponentFixture<AddPropertyPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddPropertyPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddPropertyPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
