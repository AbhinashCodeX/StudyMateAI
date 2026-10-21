# StudyMateAI 🤖

StudyMateAI is a full-stack conversational study assistant designed to help learners understand programming concepts through an interactive chat interface.

The project combines a modern Angular frontend with an ASP.NET Core Web API backend. It currently provides the foundation for a conversational learning application, with the frontend communicating with the backend through HTTP APIs.

---

## 🚀 Project Overview

StudyMateAI follows a simple full-stack architecture:

Angular Frontend
        ↓
HTTP POST Request
        ↓
ASP.NET Core Web API
        ↓
ChatController
        ↓
IChatService
        ↓
ChatService
        ↓
Response
        ↓
Angular Chat UI

The application currently contains a working chat interface where users can enter a question and receive a response from the ASP.NET Core API.

The current backend response is a placeholder response used to establish and test the complete frontend-to-backend communication flow.

---

## 🛠️ Technologies Used

### Frontend

- Angular
- TypeScript
- HTML
- CSS
- Angular Signals
- Angular Forms
- HttpClient
- Two-way Data Binding
- Event Binding
- `@for` for displaying messages

### Backend

- ASP.NET Core Web API
- C#
- Dependency Injection
- Controller → Service architecture
- HTTP POST API
- JSON request/response

### Development Tools

- Visual Studio Code
- Visual Studio
- Postman
- Git
- GitHub

---

## 📁 Project Structure

```text
StudyMateAI/
│
├── Angular/
│   └── StudyMateAI/
│       │
│       ├── public/
│       ├── src/
│       │   └── app/
│       │       ├── app.config.ts
│       │       ├── app.css
│       │       ├── app.html
│       │       ├── app.routes.ts
│       │       └── app.ts
│       │
│       ├── angular.json
│       ├── package.json
│       └── tsconfig.json
│
├── Backend/
│   └── StudyMateAPI/
│       │
│       └── StudyMateAPI/
│           ├── Controllers/
│           │   ├── ChatController.cs
│           │   └── WeatherForecastController.cs
│           │
│           ├── Models/
│           │   └── ChatRequest.cs
│           │
│           ├── Services/
│           │   ├── ChatService.cs
│           │   └── IChatService.cs
│           │
│           ├── Program.cs
│           ├── appsettings.json
│           └── StudyMateAPI.csproj
│
├── .gitignore
└── README.md
