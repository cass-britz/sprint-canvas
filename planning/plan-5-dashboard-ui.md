# Plan 5: Dashboard UI

**Status:** To Do

Goal: Build the dashboard using Angular Material and feature signal stores and wire to server

## Data integration
1. Integrate with Server: Add GraphQL client using StrawberryShake to SprintCanvas.Api to query the data service, update existing endpoints to use the data service.
2. Update Server Features: Modify or add Features/Retrospectives in SprintCanvas.Api with MediatR handlers that call the data service.

## Client integration
1. Create the dashboard feature and a dashboard signal store.
2. Build the `Retrospective Goals` card component using Angular Material.
3. Use the signal store for dashboard interaction and state management instead of a UI service.
4. Connect the signal store to API interactions and state updates.
5. Use Material responsive utilities to support mobile and desktop layouts.