import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatAiPageComponent } from './chat-ai-page.component';

describe('ChatAiPageComponent', () => {
  let component: ChatAiPageComponent;
  let fixture: ComponentFixture<ChatAiPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ChatAiPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChatAiPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
