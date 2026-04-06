# Sprint Canvas

Plan work, track it, run retros, and demos. Improve every sprint.

## Overview

Sprint Canvas is a full-stack application for agile sprint management, built with Angular (frontend), ASP.NET Core Web API (backend), and a GraphQL data service backed by AWS DynamoDB.

### Architecture

- **Client**: Angular 21 application with signals and NgRx signal stores.
- **API**: ASP.NET Core Web API (.NET 9) acting as a backend-for-frontend (BFF), proxying GraphQL requests.
- **Data**: Standalone GraphQL service (HotChocolate) with DynamoDB for data persistence.

## Features

- Sprint planning and tracking
- Retrospective management (CRUD operations)
- Health check endpoints
- CORS enabled for local development

## Prerequisites

- Node.js 18+ and npm
- .NET 9 SDK
- Docker (for local DynamoDB)
- AWS CLI (for production AWS setup)
- AWS account (for DynamoDB and S3)

## Installation

1. Clone the repository:
   ```bash
   git clone <repo-url>
   cd sprint-canvas
   ```

2. Install client dependencies:
   ```bash
   cd client
   npm install
   ```

3. Restore server dependencies:
   ```bash
   cd ../server
   dotnet restore
   ```

## Configuration

### Local Development

- **DynamoDB Local**: Use Docker Compose for local database.
- **API Keys**: Use dev keys in `appsettings.Development.json`.
- **CORS**: Allows `http://localhost:4200` for Angular dev server.

### Production

- Configure AWS credentials via `aws configure`.
- Update `appsettings.json` with production AWS region.
- Change API keys in `appsettings.json`.

## Running the Application

### Start DynamoDB Local

```bash
docker-compose up
```

### Start Data Service

```bash
cd server/SprintCanvas.Data
dotnet run
```

Runs on `http://localhost:5001/graphql`.

### Start API

```bash
cd server/SprintCanvas.Api
dotnet run
```

Runs on `http://localhost:5084`.

### Start Client

```bash
cd client
npm start
```

Runs on `http://localhost:4200`.

## API Documentation

### Health Check

- `GET /health` - Returns service health status.

### GraphQL Endpoints

The data service exposes GraphQL at `/graphql`.

#### Queries

- `retrospectives`: Get all retrospectives.
- `retrospective(id: String!)`: Get a retrospective by ID.

#### Mutations

- `createRetrospective(input: CreateRetrospectiveInput!)`: Create a new retrospective.
- `updateRetrospective(input: UpdateRetrospectiveInput!)`: Update an existing retrospective.
- `deleteRetrospective(id: String!)`: Delete a retrospective.

#### Types

```graphql
type Retrospective {
  id: String!
  sprintId: String!
  theme: String!
  actionItems: [String!]!
}

input CreateRetrospectiveInput {
  sprintId: String!
  theme: String!
  actionItems: [String!]!
}

input UpdateRetrospectiveInput {
  id: String!
  sprintId: String
  theme: String
  actionItems: [String!]
}
```

## Contributing

Use conventional commits for all changes. See https://conventionalcommits.org/ for details.

Focus commit messages on **why** a change was made, not what was changed. The diff shows what changed; the commit message explains the reasoning and context.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
