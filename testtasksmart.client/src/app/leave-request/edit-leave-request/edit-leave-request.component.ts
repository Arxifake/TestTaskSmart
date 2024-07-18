import { Component, OnInit } from '@angular/core';
import { LeaveRequest } from '../../../DTO/LeaveRequest';
import { LeaveRequestDataService } from '../leave-request.data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { formatDate } from '@angular/common';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-edit-leave-request',
  templateUrl: './edit-leave-request.component.html',
  styleUrl: './edit-leave-request.component.css',
  providers: [LeaveRequestDataService]
})
export class EditLeaveRequestComponent implements OnInit {

  leaveRequest: LeaveRequest = {
    id: 0,
    formattedId: '',
    comment: '',
    status: '',
    absenceReason: '',
    startDate: new Date(),
    endDate: new Date()
  };
  endDate: string = '';
  startDate: string = '';

  constructor(private route: ActivatedRoute, private leaveRequestService: LeaveRequestDataService, private router: Router, public authService: AuthService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const leaveRequestId = Number(params.get('id'));
      if (leaveRequestId) {
        this.loadLeaveRequest(leaveRequestId);
      }
    });
  }

  loadLeaveRequest(leaveRequestId: number): void {
    this.leaveRequestService.getLeaveReuestById(leaveRequestId).subscribe((data: LeaveRequest) => {
      this.leaveRequest = data;
    });
    this.endDate = formatDate(this.leaveRequest.endDate, "yyyy-MM-dd", "en-US");
    this.startDate = formatDate(this.leaveRequest.startDate, "yyyy-MM-dd", "en-US"); 
  }

  onSubmit(): void {
    this.leaveRequestService.updateLeaveRequest(this.leaveRequest).subscribe(() => {
      this.router.navigate(['/leaveRequests']);
    });
  }

  isNotEmployee(): boolean {
    return this.authService.getPosition() !== 'Employee';
  }
}
