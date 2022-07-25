import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeDataComponent } from './employee-data/employee-data.component';
import { EmployeeComponent } from './employee.component';
import { ProfileComponent } from './profile/profile.component';
import { ContactComponent } from './contact/contact.component';
import { AddressComponent } from './address/address.component';
import { BankAccountComponent } from './bank-account/bank-account.component';
import { FamilyDataComponent } from './family-data/family-data.component';
import { FacilityComponent } from './facility/facility.component';
import { InputDataComponent } from './input-data/input-data.component';
import { EmployeeDocumentComponent } from './employee-document/employee-document.component';
import { TransportationComponent } from './transportation/transportation.component';

const routes: Routes = [
  {
    path: '',
    component: EmployeeComponent,
    children: [
      {
        path: 'employee-data',
        component: EmployeeDataComponent,
      },
      {
        path: 'profile',
        component: ProfileComponent,
      },
      {
        path: 'contact',
        component: ContactComponent,
      },
      {
        path: 'address',
        component: AddressComponent,
      },
      {
        path: 'bank-account',
        component: BankAccountComponent,
      },
      {
        path: 'family-data',
        component: FamilyDataComponent,
      },
      {
        path: 'employee-document',
        component: EmployeeDocumentComponent,
      },
      {
        path: 'facility',
        component: FacilityComponent,
      },
      {
        path: 'transportation',
        component: TransportationComponent,
      },
      {
        path: 'input-data',
        component: InputDataComponent,
      },
      { path: '', redirectTo: 'employee-data', pathMatch: 'full' },
      { path: '**', redirectTo: 'employee-data', pathMatch: 'full' },
      
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
