# Test Project
Test task for a review for Wow 24

## Project structure

```
docker_projects/
├── docker-compose.yml
├── README.md
├── CRM.ApiService/
│   ├── Dockerfile
│   ├── Program.cs
│   ├── Controllers/
│   ├── Logs/
│   ├── Midleware/
│   ├── Models/
│   └── appsetings.json
|
├── CxNone.ApiService/
│   ├── Dockerfile
│   ├── Program.cs
│   ├── Controllers/
│   ├── Logs/
│   ├── Midleware/
│   ├── Models/
│   └── appsetings.json
|
├── Client.Console/
│   ├── Dockerfile
│   ├── Program.cs
│   ├── Models.cs
│   └── Clients/
```

## Quick start

### 1. Prerequisites

Ensure that the following are installed:

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

### 2. Build and run

In the root of the project, run the following command:

```bash
docker compose up --build
```

### 3. Access to services

After running:

- **CRM API** can be accessed at: [http://localhost:57607/swagger](http://localhost:8080)
- **CXNONE API** can be accessed at: [http://localhost:57606/swagger](http://localhost:5000)


## 🧱 Components

### 🔹CRM API Service

Description:

> Returns data from the CRM system

### 🔹CxNone API Service 

Description:

> Save data in CxNone system

### 🔸Client Console App

Console App:

>  client that receives data from the CRM system and forwards it to CxNone.

