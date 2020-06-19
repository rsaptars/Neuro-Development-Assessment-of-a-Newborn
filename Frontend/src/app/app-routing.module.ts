import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { AddPatientComponent } from './add-patient/add-patient.component';
import { MrdNumberComponent } from './mrd-number/mrd-number.component';
import { ChartsComponent } from './charts/charts.component';
import { TablesComponent } from './tables/tables.component';
import { AdvancedSearchComponent } from './advanced-search/advanced-search.component';
import { AddUsersComponent } from './add-users/add-users.component';
import { LoginComponentComponent } from './login-component/login-component.component'

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponentComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'patient', component: AddPatientComponent },
  { path: 'mrdsearch', component: MrdNumberComponent },
  { path: 'charts', component: ChartsComponent },
  { path: 'tables', component: TablesComponent },
  { path: 'search', component: AdvancedSearchComponent },
  { path: 'users', component: AddUsersComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
