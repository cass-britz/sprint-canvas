# Plan 4: Data Project Integration

**Status:** To Do

Goal: Create a separate GraphQL data service backed by AWS DynamoDB for retrospective items, including environment setup and integration with the existing API.

1. Guide user through environment Setup: Install AWS CLI on Windows, set up AWS account with access keys, create DynamoDB table for retrospectives (e.g., table name 'Retrospectives', region us-east-1), create S3 bucket for future profile pictures (e.g., 'sprint-canvas-profiles').
2. Create SprintCanvas.Data Project: Add a new ASP.NET Core Web API project to the solution with GraphQL support using HotChocolate.
3. Configure AWS SDK: Add AWSSDK.DynamoDBv2 and related packages to SprintCanvas.Data, configure credentials and region in appsettings.
4. Define Retrospective Entity: Create a Retrospective class with fields: Id (Guid), SprintId (Guid), Theme (string), ActionItems (List<string>).
5. Implement Repository: Add IRetrospectiveRepository interface and DynamoDB implementation for CRUD operations.
6. Add GraphQL Schema: Define GraphQL types, queries (get retrospectives, get by id), mutations (create, update, delete retrospective).