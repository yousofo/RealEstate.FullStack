import { Injectable } from '@angular/core';
import { GoogleGenerativeAI } from '@google/generative-ai';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class GeminiService {
  private genAI: GoogleGenerativeAI;
  private model ;

  constructor() {
    this.genAI = new GoogleGenerativeAI( environment.geminiAiKey);

    this.model = this.genAI.getGenerativeModel({ model: 'gemini-2.0-flash' });
  }

  async getChatResponse(message: string) :Promise<string>{
    try {
      const result = await this.model.generateContent(message);

      // Extract response text
      const response =  result.response;

      return response.text();
    } catch (error) {
      console.error('Error communicating with Gemini:', error);
      throw error;
    }
  }
}
