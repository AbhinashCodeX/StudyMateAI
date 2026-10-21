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

    // Add user message
    this.messages.update(messages => [
      ...messages,
      {
        sender: 'user',
        text: userMessage
      }
    ]);

    // Clear input
    this.message = '';

    // Call ASP.NET Core API
    this.http.post<any>(
      'https://localhost:7031/api/Chat/send',
      {
        message: userMessage
      }
    ).subscribe({
      
      next: (response) => {

        console.log('API RESPONSE:', response);

        // Add AI response
        this.messages.update(messages => [
          ...messages,
          {
            sender: 'ai',
            text: response.reply
          }
        ]);

      },

      error: (error) => {
        console.error('API ERROR:', error);
      }

    });
  }
}