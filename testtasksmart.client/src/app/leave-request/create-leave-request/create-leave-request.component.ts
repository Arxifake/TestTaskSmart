import { Component } from '@angular/core';
import { LeaveRequestDataService } from '../leave-request.data.service';
import { Router } from '@angular/router';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-create-leave-request',
  templateUrl: './create-leave-request.component.html',
  styleUrl: './create-leave-request.component.css',
  providers: [LeaveRequestDataService]
})
export class CreateLeaveRequestComponent {

  absenceReason: string = '';
  startDate: Date = new Date();
  endDate: Date = new Date();
  comment: string = '';

  constructor(private leaveRequestService: LeaveRequestDataService, private router: Router, public authService: AuthService) { }

  onSubmit() {
    const leaveRequest = {
      absenceReason: this.absenceReason,
      startDate: this.startDate,
      endDate: this.endDate,
      comment: this.comment,
      employeeId: this.authService.getUserId()
    };
    this.leaveRequestService.createLeaveRequest(leaveRequest).subscribe(() => {
      this.router.navigate(['/leaveRequests']);
    });
    }
}
