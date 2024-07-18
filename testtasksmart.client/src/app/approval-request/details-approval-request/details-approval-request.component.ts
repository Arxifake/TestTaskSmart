import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ApprovalRequestDataService } from '../approval-request.data.service';
import { formatDate } from '@angular/common';
import { ApprovalRequest } from '../../../DTO/ApprovalRequest';

@Component({
  selector: 'app-details-approval-request',
  templateUrl: './details-approval-request.component.html',
  styleUrl: './details-approval-request.component.css',
  providers: [ApprovalRequestDataService]
})
export class DetailsApprovalRequestComponent {

  approvalRequest: ApprovalRequest = {
    id: 0,
    employee: {
      id: 0,
      fullName: ''
    },
    formattedId: '',
    comment: '',
    status: '',
    leaveRequest: {
      id: 0,
      formattedId: '',
      absenceReason: '',
      status: '',
      startDate: new Date(),
      endDate: new Date(),
      comment: '',
      employee: {
        id: 0,
        fullName: ''
      }
    },
    isSubmited: true
  };
  endDate: string = '';
  startDate: string = '';
  numberOfDays: number = 0;

  constructor(private route: ActivatedRoute, private approvalRequestService: ApprovalRequestDataService, private router: Router, public authService: AuthService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const approvalRequestId = Number(params.get('id'));
      if (approvalRequestId) {
        this.loadApprovalRequest(approvalRequestId);
      }
    });
    
  }

  loadApprovalRequest(approvalRequestId: number): void {
    this.approvalRequestService.getApprovalReuestById(approvalRequestId).subscribe((data: ApprovalRequest) => {
      this.approvalRequest = data;
    });
    this.endDate = formatDate(this.approvalRequest.leaveRequest.endDate, "yyyy-MM-dd", "en-US");
    this.startDate = formatDate(this.approvalRequest.leaveRequest.startDate, "yyyy-MM-dd", "en-US");
  }

  approveRequest(id: number): void {
    this.approvalRequestService.approveRequest(id).subscribe(() => {
      this.router.navigate(['/approvalRequests']);
    });
  }

  rejectRequest(id: number): void {
    this.approvalRequestService.rejectRequest(id).subscribe(() => {
      this.router.navigate(['/approvalRequests']);
    });
  }
}

