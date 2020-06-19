import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AddPatientComponent } from './add-patient/add-patient.component';
import { MrdNumberComponent } from './mrd-number/mrd-number.component';
import { ChartsComponent } from './charts/charts.component';
import { TablesComponent } from './tables/tables.component';
import { AdvancedSearchComponent } from './advanced-search/advanced-search.component';
import { AddUsersComponent } from './add-users/add-users.component';
import { ExportToExcelComponent } from './export-to-excel/export-to-excel.component';
import { LoginComponentComponent } from './login-component/login-component.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    AddPatientComponent,
    MrdNumberComponent,
    ChartsComponent,
    TablesComponent,
    AdvancedSearchComponent,
    AddUsersComponent,
    ExportToExcelComponent,
    LoginComponentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    RouterModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
