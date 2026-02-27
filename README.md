**A RESTful Web API for tracking job applications and companies, built with .NET 8.**

This is the backend service for the ReatsTracker ecosystem.

## 🛠 Tech Stack
* **Framework:** .NET 8 (C#)
* **Database:** PostgreSQL
* **ORM:** Entity Framework Core
* **Infrastructure:** Docker, Terraform (Azure), GitHub Actions (CI/CD)

## 📦 Related Projects (Clients)
[ReatsTracker Desktop (WPF)](https://github.com/ТВОЙ_НИК/reats-tracker-desktop) - Windows Desktop Client

## 🚀 How to Run Locally

1. Clone the repository:
   ```bash
   git clone https://github.com/vzalxndr/reats-tracker-api.git
   ```

2. Start the database and pgAdmin using Docker Compose:
   ```bash
   docker compose up db pgadmin -d
   ```

3. Apply database migrations:
   ```bash
   dotnet ef database update --project ReatsTracker.Api
   ```

4. Run the API:
   ```bash
   dotnet run --project ReatsTracker.Api
   ```

5. Swagger UI will be available at: `http://localhost:<port>/swagger`