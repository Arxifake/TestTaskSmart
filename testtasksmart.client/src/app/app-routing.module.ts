import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './employee/employee.component';
import { AddEmployeeComponent } from './employee/add-employee/add-employee.component';
import { EditEmployeeComponent } from './employee/edit-employee/edit-employee.component';
import { LoginComponent } from './login/login.component';
import { LeaveRequestComponent } from './leave-request/leave-request.component';
import { ApprovalRequestComponent } from './approval-request/approval-request.component';
import { CreateLeaveRequestComponent } from './leave-request/create-leave-request/create-leave-request.component';
import { EditLeaveRequestComponent } from './leave-request/edit-leave-request/edit-leave-request.component';
import { DetailsApprovalRequestComponent } from './approval-request/details-approval-request/details-approval-request.component';
import { ProjectComponent } from './project/project.component';

const routes: Routes = [
  { path: 'employees', component: EmployeeComponent },
  { path: 'employees/add', component: AddEmployeeComponent },
  { path: 'employees/edit/:id', component: EditEmployeeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'leaveRequests', component: LeaveRequestComponent },
  { path: 'leaveRequests/create', component: CreateLeaveRequestComponent },
  { path: 'leaveRequests/edit/:id', component: EditLeaveRequestComponent },
  { path: 'approvalRequests', component: ApprovalRequestComponent },
  { path: 'approvalRequests/details/:id', component: DetailsApprovalRequestComponent },
  { path: 'projects', component: ProjectComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
