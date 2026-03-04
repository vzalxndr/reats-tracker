# ReatsTracker API 🚀

[![Deploy to Azure (Staging & Prod)](https://github.com/vzalxndr/reats-tracker/actions/workflows/deploy.yml/badge.svg)](https://github.com/vzalxndr/reats-tracker/actions/workflows/deploy.yml)
[![Build and Publish Docker Image](https://github.com/vzalxndr/reats-tracker/actions/workflows/docker-publish.yml/badge.svg)](https://github.com/vzalxndr/reats-tracker/actions/workflows/docker-publish.yml)
[![CodeQL Security Scan](https://github.com/vzalxndr/reats-tracker/actions/workflows/codeql.yml/badge.svg)](https://github.com/vzalxndr/reats-tracker/actions/workflows/codeql.yml)

A RESTful Web API for tracking job applications and companies. This is the core backend service for the ReatsTracker ecosystem, built with a focus on modern cloud infrastructure, security, and CI/CD automation.

## 🛠 Tech Stack

**Backend:**
* **Framework:** .NET 8 (C#)
* **Database:** PostgreSQL (Hosted on Neon.tech Serverless)
* **ORM:** Entity Framework Core

**DevOps & Cloud Infrastructure:**
* **Cloud Provider:** Microsoft Azure (Linux Web Apps)
* **Infrastructure as Code (IaC):** Terraform
* **Containerization:** Docker & GitHub Container Registry (GHCR)
* **CI/CD:** GitHub Actions (Multi-stage deployments)
* **Observability:** Azure Application Insights & Log Analytics Workspace
* **DevSecOps:** GitHub CodeQL for automated vulnerability scanning

---

## 🏗️ Infrastructure Overview
This project features an Enterprise-grade DevOps pipeline:
1. **Multi-stage Deployment:** Automated testing and deployment to `Staging` environment, followed by `Production` upon success.
2. **Infrastructure as Code:** All Azure resources (Resource Groups, Service Plans, Web Apps, Telemetry) are provisioned and managed via Terraform (`/terraform` directory).
3. **Automated Containerization:** Every merge to `main` builds a highly optimized multi-stage Docker image and publishes it to GHCR.
4. **Security First:** GitHub CodeQL automatically scans C# code for vulnerabilities (SQL injection, hardcoded secrets) on every Pull Request.
5. **Observability:** Fully integrated with Azure Application Insights for live metrics, failure rates, and Application Map tracing.

---

## 📦 Related Projects (Clients)
* [ReatsTracker Desktop (WPF)](https://github.com/vzalxndr/reats-tracker-desktop) - Windows Desktop Client

---

## 🚀 How to Run Locally

### Option 1: Using .NET CLI & Docker Compose

1. Clone the repository:
   ```bash
   git clone https://github.com/vzalxndr/reats-tracker.git
   cd reats-tracker
   ```

2. Start the local database and pgAdmin using Docker Compose:
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

* Swagger UI will be available at: http://localhost:<port>/swagger

---

### Option 2: Run via Pre-built Docker Image

1. Pull the latest image:
   ```bash
   docker pull ghcr.io/vzalxndr/reats-tracker:main
   ```

2. Run the container (replace <YOUR_CONNECTION_STRING> with your PostgreSQL credentials):
   ```bash
   docker run -d -p 8080:8080 -e "ConnectionStrings__DefaultConnection=<YOUR_CONNECTION_STRING>" --name reatstracker-api ghcr.io/vzalxndr/reats-tracker:main
   ```

* The API will be accessible at: http://localhost:8080

