import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChoosePropertyLocationComponent } from './choose-property-location.component';

describe('ChoosePropertyLocationComponent', () => {
  let component: ChoosePropertyLocationComponent;
  let fixture: ComponentFixture<ChoosePropertyLocationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChoosePropertyLocationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChoosePropertyLocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
