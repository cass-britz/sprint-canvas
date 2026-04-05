# sprint-canvas
Plan work, track it, run retros, and demos. Improve every sprint

## Contributing

Use conventional commits for all changes. See https://conventionalcommits.org/ for details.

Focus commit messages on **why** a change was made, not what was changed. The diff shows what changed; the commit message explains the reasoning and context.

## Backend Server

The backend API lives in the `server/` folder.

### Running the backend locally

```bash
cd server
dotnet build
cd SprintCanvas.Api
dotnet run
```

Then open: `http://localhost:5084/health`

### Notes

- The backend uses **ASP.NET Core Web API (.NET 9)**.
- It is organized by **feature**, not by controller/handler layers.
- Requests from the Angular frontend are allowed via CORS for `http://localhost:4200`.
- Authentication and data persistence are deferred to later plans.
