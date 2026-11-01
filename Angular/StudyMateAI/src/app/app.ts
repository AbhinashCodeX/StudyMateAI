import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  imports: [FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {

  message = '';
  isThinking = signal(false);
  messages = signal([
    {
      sender: 'ai',
      text: 'Hello! I am StudyMate AI. How can I help you?'
    }
  ]);

  constructor(private http: HttpClient) {}

 
sendMessage() {

  if (this.message.trim() === '') {
    return;
  }

  const userMessage = this.message.trim();

  // 1. Add user message
  this.messages.update(messages => [
    ...messages,
    {
      sender: 'user',
      text: userMessage
    }
  ]);

  // 2. Clear input
  this.message = '';

  // 3. Convert all messages into Ollama format
  const chatHistory = this.messages().map(msg => ({
    role: msg.sender === 'ai' ? 'assistant' : 'user',
    content: msg.text
  }));

  // 4. Show thinking indicator
  this.isThinking.set(true);

  // 4. Send conversation history to ASP.NET Core API
  this.http.post<any>(
    'https://localhost:7031/api/Chat/send',
    {
      messages: chatHistory
    }
  ).subscribe({

    next: (response) => {

      console.log('API RESPONSE:', response);

      // Stop thinking indicator
      this.isThinking.set(false);

      // 5. Add AI response
      this.messages.update(messages => [
        ...messages,
        {
          sender: 'ai',
          text: response.reply
        }
      ]);

    },

    error: (error) => {
    // Stop thinking indicator
    this.isThinking.set(false);

      console.error('API ERROR:', error);
    }

  });
}

}