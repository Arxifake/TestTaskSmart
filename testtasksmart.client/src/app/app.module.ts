import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AuthService } from './auth.service';
import { EmployeeComponent } from './employee/employee.component';
import { AddEmployeeComponent } from './employee/add-employee/add-employee.component';
import { EditEmployeeComponent } from './employee/edit-employee/edit-employee.component';
import { LeaveRequestComponent } from './leave-request/leave-request.component';
import { LoginComponent } from './login/login.component';
import { ApprovalRequestComponent } from './approval-request/approval-request.component';
import { CreateLeaveRequestComponent } from './leave-request/create-leave-request/create-leave-request.component';
import { EditLeaveRequestComponent } from './leave-request/edit-leave-request/edit-leave-request.component';
import { DetailsApprovalRequestComponent } from './approval-request/details-approval-request/details-approval-request.component';
import { ProjectComponent } from './project/project.component';
import { AddProjectComponent } from './project/add-project/add-project.component';
import { EditProjectComponent } from './project/edit-project/edit-project.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    EmployeeComponent,
    AddEmployeeComponent,
    EditEmployeeComponent,
    LeaveRequestComponent,
    LoginComponent,
    ApprovalRequestComponent,
    EditLeaveRequestComponent,
    CreateLeaveRequestComponent,
    DetailsApprovalRequestComponent,
    ProjectComponent,
    AddProjectComponent,
    EditProjectComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
