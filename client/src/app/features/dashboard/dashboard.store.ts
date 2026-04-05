import { signalStore, withState } from '@ngrx/signals';

export interface DashboardState {
  title: string;
  subtitle: string;
}

export const dashboardInitialState: DashboardState = {
  title: 'Sprint Canvas Dashboard',
  subtitle: 'Track sprint progress, plan work, and stay aligned.'
};

export const DashboardStore = signalStore(
  withState(dashboardInitialState)
);