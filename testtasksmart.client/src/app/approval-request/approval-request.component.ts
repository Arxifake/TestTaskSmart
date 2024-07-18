import { Component, OnInit } from '@angular/core';
import { ApprovalRequestDataService } from './approval-request.data.service'
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { PaginationDTO } from '../../DTO/PaginationDTO';
import { ApprovalRequest } from '../../DTO/ApprovalRequest';

@Component({
  selector: 'app-approval-request',
  templateUrl: './approval-request.component.html',
  styleUrl: './approval-request.component.css',
  providers: [ApprovalRequestDataService]
})
export class ApprovalRequestComponent implements OnInit {

  page!: PaginationDTO<ApprovalRequest>;
  searchString: string = '';

  constructor(private ardataservice: ApprovalRequestDataService, private router: Router, public authService: AuthService) { }

  ngOnInit() {
    this.loadApprovalRequests('', '', '', 1);
  }

  loadApprovalRequests(sortBy: string, sortType: string, searchString: string, pageNumber: number) {
    if (sortBy == null) sortBy = '';
    if (sortType == null) sortType = '';
    if (searchString == null) searchString = '';
    if (pageNumber == null) pageNumber = 1;
    this.ardataservice.getApprovalRequests(sortBy, sortType, searchString, pageNumber)
      .subscribe((data: PaginationDTO<ApprovalRequest>) => this.page = data);

  }

  viewApprovalRequest(id: number) {
    this.router.navigate(['/approvalRequests/details', id]);
  }
}

