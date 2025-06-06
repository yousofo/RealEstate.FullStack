import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnterPropertyInfo } from './enter-property-info';

describe('EnterPropertyInfo', () => {
  let component: EnterPropertyInfo;
  let fixture: ComponentFixture<EnterPropertyInfo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EnterPropertyInfo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EnterPropertyInfo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
