# Agent Standards for sprint-canvas

## Purpose
This file is a minimal reference for agents. Use it to confirm that work follows external best practices and the YAGNI principle. Use it to determine session continuation.

## Session continuation
ALWAYS use the vscode askQuestions tool after you have responded. Ask the user if they have more questions or if they would like to end the session. If they end the session, end gracefully. Else, continue the session.

## Reference Sites
- Angular Style Guide: https://angular.io/guide/styleguide
- Angular Signals: https://angular.io/guide/signals
- NgRx Signal Store: https://ngrx.io/guide/store/signals
- Microsoft Architecture: https://learn.microsoft.com/dotnet/architecture/
- .NET Best Practices: https://learn.microsoft.com/dotnet/
- Medi8r / Mediatr patterns: https://github.com/mediatr/mediatr
- YAGNI principle: https://en.wikipedia.org/wiki/You_ain%27t_gonna_need_it

## Key Rules
- Use Angular 21, ASP.NET Core Web API on .NET 9, and Medi8r handlers.
- Use Angular signals and ngrx signal stores for feature state.
- Use SCSS and include the global style file on the main component via its `styleUrls`.
- Use inline component templates and avoid separate HTML template files.
- Use conventional commit standard for all commits, focusing on the **why** rather than the **what** in the commit message.
- Avoid placeholder files/folders with no documents or content.
- Follow YAGNI: do not overbuild, avoid empty structures, avoid early optimization.
- Prefer minimal logging in backend code.
- Write self-documenting code. Avoid adding comments for self explanatory code.
- Keep architecture simple and scalable across frontend, backend, and data projects.
