import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <section class="dashboard-page">
      <h1>Dashboard</h1>
      <p>Welcome to Sprint Canvas. Use this dashboard to plan sprints, manage progress, and review results.</p>
    </section>
  `,
  styleUrls: ['./dashboard.scss']
})
export class DashboardComponent {}
