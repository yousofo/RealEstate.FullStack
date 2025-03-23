import { Component } from '@angular/core';
import { ChatAIComponent } from '../../lib/components/chat-ai/chat-ai.component';

@Component({
  selector: 'app-chat-ai-page',
  standalone: true,
  templateUrl: './chat-ai-page.component.html',
  styleUrl: './chat-ai-page.component.css',
  imports: [ChatAIComponent]
})
export class ChatAiPageComponent {

}
