# Naborious Coffee Restaurant

Welcome to **Naborious Coffee**, a full-stack web application designed for a cozy café experience. This project dynamically renders menu items (coffees, Canadian sweets, and other desserts) pulled directly from a relational database.

## Tech Stack

* **Backend:** C# / .NET 10 (ASP.NET Core MVC)
* **Database:** SQLite & Entity Framework Core (EF Core)
* **Frontend:** HTML5, CSS3, JavaScript (ES6 Modules)

## How to Run the Project

1. Clone this repository:
   ```bash
   git clone https://github.com/gglocimosRework/Naborious-Coffee-FS/new/main?filename=README.md
   ```
   - Navigate to the project folder and restore dependencies:
     
     ```dotnet
     dotnet restore
     ```
     Update the database:
     
     ```dotnet
     dotnet ef database update
     ```
     Run the application:
     
     ```dotnet
     dotnet watch
     ```
