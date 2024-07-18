import { Component, OnInit } from '@angular/core';
import { LeaveRequestDataService } from './leave-request.data.service'
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { PaginationDTO } from '../../DTO/PaginationDTO';
import { LeaveRequest } from '../../DTO/LeaveRequest';

@Component({
  selector: 'app-leave-request',
  templateUrl: './leave-request.component.html',
  styleUrl: './leave-request.component.css',
  providers: [LeaveRequestDataService]
})
export class LeaveRequestComponent implements OnInit {

  page!: PaginationDTO<LeaveRequest>;
  searchString: string = '';
  buttonText: string = '';

  constructor(private lrdataservice: LeaveRequestDataService, private router: Router, public authService: AuthService) { }

  ngOnInit() {
    this.loadLeaveRequests('', '', '', 1);
    this.setButtonText();
  }

  loadLeaveRequests(sortBy: string, sortType: string, searchString: string, pageNumber: number) {
    if (sortBy == null) sortBy = '';
    if (sortType == null) sortType = '';
    if (searchString == null) searchString = '';
    if (pageNumber == null) pageNumber = 1;
    let id: number | null = null;
    if (!this.isNotEmployee()) {
      id = this.authService.getUserId();
    }
    this.lrdataservice.getLeaveRequests(sortBy, sortType, searchString, pageNumber, id)
      .subscribe((data: PaginationDTO<LeaveRequest>) => this.page = data);
  }

  isNotEmployee(): boolean {
    return this.authService.getPosition() !== 'Employee';
  }

  setButtonText(): void {
    const role = this.authService.getPosition();
    this.buttonText = this.isNotEmployee() ? 'Details' : 'Edit';
  }

  editLeaveRequest(id: number): void {
    this.router.navigate(['/leaveRequests/edit', id]);
  }

  createLeaveRequest(): void {
    this.router.navigate(['/leaveRequests/create']);
  }

  submitLeaveRequest(id: number): void {
    this.lrdataservice.submitLeaveRequest(id).subscribe(() => {
      this.loadLeaveRequests(this.page.sortBy!, this.page.sortType!, this.page.searchString!, this.page?.pageIndex ?? 1);
    });
  }

  cancelLeaveRequest(id: number): void {
    this.lrdataservice.cancelLeaveRequest(id).subscribe(() => {
      this.loadLeaveRequests(this.page.sortBy!, this.page.sortType!, this.page.searchString!, this.page?.pageIndex ?? 1);
    });
  }
}

