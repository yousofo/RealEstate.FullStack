import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminPropertiesPageComponent } from './admin-properties-page.component';

describe('AdminPropertiesPageComponent', () => {
  let component: AdminPropertiesPageComponent;
  let fixture: ComponentFixture<AdminPropertiesPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdminPropertiesPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminPropertiesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
