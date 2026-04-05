# Plan 4: Data Project Integration

Goal: Add a shared `data` project and Azure Cosmos DB integration with user profile support.

1. Help user to setup environment. Document required tools: .NET 9 SDK, Azure CLI, Cosmos DB account, and Azure access keys.
2. Create a shared `data` project for common models, DTOs, and repository logic.
3. Configure Azure Cosmos DB SDK for NoSQL in backend and `data` project.
4. Add a `User` entity that supports profile picture blob storage; do not add a dashboard card entity.
5. Add repository abstractions for user/profile persistence and access.