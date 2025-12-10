# Safer

Travel organizer application.

## Prerequisites
- .NET 8 SDK
- Docker & Docker Compose

## Getting Started

### 1. Start Infrastructure
Start the required services (PostgreSQL, Redis, RabbitMQ):
```bash
docker-compose up -d
```

### 2. Run API Gateway
The API Gateway is the entry point for the application.
```bash
cd src/Gateways/Safer.ApiGateway
dotnet run
```
The gateway will be available at `https://localhost:7001` (or similar, check console output).

### 3. Run Microservices
Run the template microservice (in a separate terminal):
```bash
cd src/Services/Safer.Services.Template
dotnet run
```

## Project Structure
- `src/BuildingBlocks`: Shared code (DDD, CQRS, EventBus).
- `src/Gateways`: API Gateways (Ocelot).
- `src/Services`: Microservices.
- `k8s/`: Kubernetes manifests.

## Shutdown
To stop the application:
1. Stop the running `dotnet run` commands (Ctrl+C in the terminal).
2. Stop the infrastructure:
```bash
docker-compose down
```

