import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeComponent } from './employee.component';
import { EmployeeDataComponent } from './employee-data/employee-data.component';
import { ProfileComponent } from './profile/profile.component';
import { ContactComponent } from './contact/contact.component';
import { AddressComponent } from './address/address.component';
import { BankAccountComponent } from './bank-account/bank-account.component';
import { FamilyDataComponent } from './family-data/family-data.component';
import { EmployeeDocumentComponent } from './employee-document/employee-document.component';
import { FacilityComponent } from './facility/facility.component';
import { TransportationComponent } from './transportation/transportation.component';
import { InputDataComponent } from './input-data/input-data.component';


@NgModule({
  declarations: [
    EmployeeComponent,
    EmployeeDataComponent,
    ProfileComponent,
    ContactComponent,
    AddressComponent,
    BankAccountComponent,
    FamilyDataComponent,
    EmployeeDocumentComponent,
    FacilityComponent,
    TransportationComponent,
    InputDataComponent
  ],
  imports: [
    CommonModule,
    EmployeeRoutingModule
  ]
})
export class EmployeeModule { }
