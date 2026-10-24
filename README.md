# StudyMateAI 🤖

StudyMateAI is a full-stack AI-powered conversational study assistant designed to help learners understand programming concepts through an interactive chat interface.

The project combines an **Angular frontend**, **ASP.NET Core Web API backend**, and a **locally running AI model through Ollama** to create an end-to-end conversational experience.

The current implementation allows users to ask programming-related questions from the Angular UI and receive AI-generated responses from a locally hosted **Llama 3.2 1B** model.

---

## 🚀 Project Overview

StudyMateAI follows a layered architecture where the Angular frontend communicates with the ASP.NET Core backend, which then communicates with the local AI model through Ollama.

```text
User
  ↓
Angular Chat UI
  ↓
Angular HttpClient
  ↓
ASP.NET Core Web API
  ↓
ChatController
  ↓
IChatService
  ↓
ChatService
  ↓
IAiService
  ↓
AiService
  ↓
Ollama
  ↓
Llama 3.2 1B
  ↓
AI Response
  ↓
Angular Chat UI
```

This architecture keeps the frontend, API logic, business logic, and AI integration separated into different layers.

---

## ✨ Current Features

- 💬 Interactive chat interface
- 🤖 AI-generated responses
- 🧠 Local AI model using Ollama
- 🔗 Angular-to-ASP.NET Core API communication
- ⚡ Asynchronous API calls using `async` / `await`
- 🧩 Dependency Injection
- 🏗️ Controller → Service architecture
- 🔌 HTTP POST API
- 📦 JSON request/response handling
- 🔄 Dynamic message rendering in Angular
- 📜 Chat interface with automatic message display

---

## 🛠️ Technologies Used

### Frontend

- Angular
- TypeScript
- HTML
- CSS
- Angular Signals
- Angular Forms
- `HttpClient`
- Two-way Data Binding `[(ngModel)]`
- Event Binding `(click)`
- `@for` for displaying messages

### Backend

- ASP.NET Core Web API
- C#
- Dependency Injection
- Interfaces
- Service Layer
- `async` / `await`
- `HttpClient`
- REST API
- JSON

### AI

- Ollama
- Llama 3.2 1B

### Development Tools

- Visual Studio
- Visual Studio Code
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
│       │
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
│           │   ├── IChatService.cs
│           │   ├── AiService.cs
│           │   └── IAiService.cs
│           │
│           ├── Program.cs
│           ├── appsettings.json
│           └── StudyMateAPI.csproj
│
├── .gitignore
└── README.md
```

---

## 🔄 How It Works

When a user enters a question in the StudyMateAI chat interface:

### 1. User enters a question

For example:

```text
What is Angular?
```

### 2. Angular sends the request

The Angular application uses `HttpClient` to send the question to the ASP.NET Core API.

```text
Angular
   ↓
POST /api/Chat/send
```

### 3. ChatController receives the request

The `ChatController` receives the user's message and passes it to the chat service.

```text
ChatController
      ↓
IChatService
```

### 4. ChatService processes the request

`ChatService` handles the chat-related application logic and communicates with the AI service.

```text
ChatService
      ↓
IAiService
```

### 5. AiService communicates with Ollama

The AI service sends the prompt to the locally running Ollama server.

```text
AiService
    ↓
Ollama
    ↓
Llama 3.2 1B
```

### 6. AI generates a response

Llama processes the question and generates a response.

### 7. Response returns to Angular

The response travels back through the API:

```text
Llama 3.2 1B
     ↓
Ollama
     ↓
AiService
     ↓
ChatService
     ↓
ChatController
     ↓
Angular
```

The response is then displayed in the chat interface.

---

## 🧪 Example

### User

```text
What is Angular?
```

### StudyMateAI

```text
Angular is a web application framework developed by Google
for building dynamic and interactive web applications.
```

The response is generated locally using the Llama model running through Ollama.

---

## ▶️ Running the Project

### Prerequisites

Make sure you have the following installed:

- .NET SDK
- Node.js
- Angular CLI
- Ollama
- Git

---

### 1. Clone the repository

```bash
git clone <your-github-repository-url>
cd StudyMateAI
```

---

### 2. Start Ollama

Make sure Ollama is installed and running.

Check the installed version:

```bash
ollama --version
```

Check available models:

```bash
ollama list
```

Make sure the required model is available:

```bash
llama3.2:1b
```

If it is not installed:

```bash
ollama pull llama3.2:1b
```

---

### 3. Run the ASP.NET Core Backend

Open the backend project in Visual Studio and run the application.

The API will be available through the configured HTTP/HTTPS ports.

Example:

```text
https://localhost:7031
```

The chat endpoint is:

```text
POST /api/Chat/send
```

---

### 4. Run the Angular Frontend

Open the Angular project in Visual Studio Code.

Navigate to:

```bash
cd Angular/StudyMateAI
```

Install dependencies:

```bash
npm install
```

Start the Angular development server:

```bash
ng serve
```

Then open the Angular application in your browser.

---

## 🧪 Testing the API

The API can also be tested independently using Postman.

### Request

```text
POST https://localhost:7031/api/Chat/send
```

### Example Request Body

```json
{
  "message": "What is Angular?"
}
```

### Example Response

```json
{
  "reply": "Angular is a web application framework..."
}
```

---

## 🏗️ Architecture

StudyMateAI uses separation of responsibilities between different layers.

```text
┌──────────────────────────┐
│      Angular Frontend    │
│                          │
│     Chat UI + Forms      │
└────────────┬─────────────┘
             │ HTTP
             ↓
┌──────────────────────────┐
│   ASP.NET Core Web API   │
│                          │
│      ChatController      │
└────────────┬─────────────┘
             ↓
┌──────────────────────────┐
│       ChatService        │
│                          │
│    IChatService          │
└────────────┬─────────────┘
             ↓
┌──────────────────────────┐
│        AiService         │
│                          │
│       IAiService         │
└────────────┬─────────────┘
             ↓
┌──────────────────────────┐
│          Ollama          │
│                          │
│      Llama 3.2 1B        │
└──────────────────────────┘
```

---

## 🎯 Learning Goals

This project is also being developed as a practical learning project to understand how a modern full-stack AI application works.

Through StudyMateAI, the following concepts are being explored:

- Angular fundamentals
- TypeScript
- Angular component architecture
- Data binding
- Angular forms
- HTTP communication
- ASP.NET Core Web API
- Dependency Injection
- Interfaces
- Service-based architecture
- REST APIs
- JSON
- Asynchronous programming
- AI integration
- Local LLMs
- Ollama
- Frontend-to-backend communication

---

## 🔮 Planned Features

The project is being developed incrementally. Planned improvements include:

- 🧠 Conversation memory
- 💾 Chat history
- 🗄️ SQL Server integration
- 👤 User authentication
- 🔐 JWT-based authorization
- 📚 Study-focused AI responses
- 📝 Learning and practice modes
- ❓ Quiz generation
- 📊 User learning progress
- 🎯 Personalized study assistance

These features will be added progressively as the project evolves.

---

## 📌 Current Status

### Phase 1 — Full-Stack Chat Foundation ✅

```text
Angular UI                    ✅
        ↓
HTTP Communication            ✅
        ↓
ASP.NET Core API              ✅
        ↓
Controller                    ✅
        ↓
Chat Service                  ✅
        ↓
AI Service                    ✅
        ↓
Ollama                        ✅
        ↓
Llama 3.2 1B                 ✅
        ↓
AI Response                   ✅
```

### Next Phase

```text
Conversation Memory
        ↓
Chat History
        ↓
SQL Server
        ↓
Authentication
        ↓
Personalized Study Assistant
```

---

## 👨‍💻 Project Purpose

StudyMateAI is being developed as a hands-on full-stack AI project to understand how **Angular, ASP.NET Core Web API, and locally hosted Large Language Models** can work together to build a practical AI application.

The goal is to gradually evolve the project from a simple chatbot into a complete AI-powered study assistant.

---

## ⭐ Future Vision

The long-term goal is to make StudyMateAI more than just a chatbot.

```text
              StudyMateAI
                   │
       ┌───────────┼───────────┐
       ↓           ↓           ↓
   Ask Questions  Practice   Learn
       │           │           │
       ↓           ↓           ↓
     AI Chat      Quizzes    Explanations
       │           │           │
       └───────────┼───────────┘
                   ↓
            Learning History
                   ↓
          Personalized Study
```

> Built as a learning project to explore full-stack development and local AI integration.
