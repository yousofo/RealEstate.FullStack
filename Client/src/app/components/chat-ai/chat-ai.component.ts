import {
  Component,
  ViewChild,
  ElementRef,
  AfterViewChecked,
  OnInit,
} from '@angular/core';
// import { GeminiService } from '../../services/gemini.service';
import { FormsModule } from '@angular/forms';
import { NgClass, NgFor, NgIf, DatePipe } from '@angular/common';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

interface ChatMessage {
  role: 'user' | 'assistant' | 'bot';
  content: string;
  timestamp: Date;
}

@Component({
  selector: 'app-chat-ai',
  templateUrl: './chat-ai.component.html',
  styleUrls: ['./chat-ai.component.scss'],
  standalone: true,
  imports: [FormsModule, NgFor, NgClass, NgIf, DatePipe],
})
export class ChatAIComponent implements OnInit, AfterViewChecked {
  chatHistory: ChatMessage[] = [];
  @ViewChild('scrollContainer') private scrollContainer!: ElementRef;
  input: string = '';
  isTyping: boolean = false;

  constructor(
    // private geminiService: GeminiService,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit() {
    // Add a welcome message
    this.chatHistory.push({
      role: 'assistant',
      content: 'Hello! How can I assist you today?',
      timestamp: new Date(),
    });
  }

  ngAfterViewChecked() {
    this.scrollToBottom();
  }

  scrollToBottom(): void {
    try {
      this.scrollContainer.nativeElement.scrollTop =
        this.scrollContainer.nativeElement.scrollHeight;
    } catch (err) {
      console.error('Error scrolling to bottom:', err);
    }
  }

  async sendMessage() {
    if (!this.input.trim()) return;

    // Add user message to chat
    this.chatHistory.push({
      role: 'user',
      content: this.input,
      timestamp: new Date(),
    });

    const userMessage = this.input;
    this.input = '';

    // Show typing indicator
    this.isTyping = true;

    // try {
    //   // Get AI response
    //   // const aiResponse = await this.geminiService.getChatResponse(userMessage);

    //   // Hide typing indicator
    //   this.isTyping = false;

    //   // Add AI response to chat
    //   this.chatHistory.push({
    //     role: 'assistant', // Changed from 'bot' to match your HTML/CSS
    //     content: aiResponse,
    //     timestamp: new Date(),
    //   });
    // } catch (error) {
    //   console.error('Error getting response from Gemini:', error);

    //   // Hide typing indicator
    //   this.isTyping = false;

    //   // Add error message
    //   this.chatHistory.push({
    //     role: 'assistant',
    //     content:
    //       'Sorry, I encountered an error processing your request. Please try again.',
    //     timestamp: new Date(),
    //   });
    // }
  }

  // Format message to handle markdown-like syntax
  formatMessage(content: string): SafeHtml {
    // Simple formatting for code blocks
    let formatted = content.replace(
      /`([^`]+)`/g,
      '<code class="bg-gray-100 dark:bg-gray-700 px-1 py-0.5 rounded text-sm">$1</code>'
    );

    // Convert URLs to links
    formatted = formatted.replace(
      /(https?:\/\/[^\s]+)/g,
      '<a href="$1" target="_blank" class="text-blue-500 underline">$1</a>'
    );

    // Handle line breaks
    formatted = formatted.replace(/\n/g, '<br>');

    return this.sanitizer.bypassSecurityTrustHtml(formatted);
  }

  // Dynamically adjust textarea rows based on content
  getRows(): number {
    const lineCount = (this.input.match(/\n/g) || []).length + 1;
    return Math.min(5, Math.max(1, lineCount));
  }

  // Handle enter key to send message, but allow shift+enter for new line
  handleEnterKey(event: Event): void {
    if (
      (event as KeyboardEvent).key === 'Enter' &&
      !(event as KeyboardEvent).shiftKey
    ) {
      event.preventDefault();
      this.sendMessage();
    }
  }
}
