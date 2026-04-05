# Plan 4: Data Project Integration

**Status:** To Do

Goal: Add a shared `data` project and AWS DynamoDB integration with user profile support.

1. Help user to setup environment. Document required tools: .NET 9 SDK, AWS CLI, DynamoDB table, S3 bucket, and AWS access keys.
2. Create a shared `data` project for common models, DTOs, and repository logic.
3. Configure AWS DynamoDB SDK for NoSQL in backend and `data` project.
4. Add a `User` entity that supports profile picture blob storage; do not add a dashboard card entity.
5. Add repository abstractions for user/profile persistence and access.