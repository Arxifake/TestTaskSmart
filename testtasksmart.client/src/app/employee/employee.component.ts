import { Component, OnInit } from '@angular/core';
import { EmployeeDataService } from './employee.data.service';
import { PaginationDTO } from '../../DTO/PaginationDTO';
import { PublicEmployeeDTO } from '../../DTO/EmployeePublicDTO';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css',
  providers: [EmployeeDataService]
})
export class EmployeeComponent implements OnInit {
  page!: PaginationDTO<PublicEmployeeDTO>;
  searchString: string = '';
  buttonText: string = '';

  constructor(private employeedataservice: EmployeeDataService, private router: Router, public authService: AuthService) { }

  ngOnInit() {
    this.loadEmployees('', '', '', 1);
    this.setButtonText();
  }

  loadEmployees(sortBy: string, sortType: string, searchString: string, pageNumber: number) {
    if (sortBy == null) sortBy = '';
    if (sortType == null) sortType = '';
    if (searchString == null) searchString = '';
    if (pageNumber == null) pageNumber = 1;
    this.employeedataservice.getEmployees(sortBy, sortType, searchString, pageNumber)
      .subscribe((data: PaginationDTO<PublicEmployeeDTO>) => this.page = data);
  }

  changeStatus(id: number): void {
    this.employeedataservice.changeStatus(id).subscribe(() => {
      this.loadEmployees(this.page.sortBy!, this.page.sortType!, this.page.searchString!, this.page?.pageIndex ?? 1);
    });
  }

  AddEmployee(): void {
    this.router.navigate(['/employees/add']);
  }

  EditEmployee(id: number): void {
    this.router.navigate(['/employees/edit', id]);
  }

  isNotPM(): boolean {
    return this.authService.getPosition() !== 'PM';
  }

  setButtonText(): void {
    const role = this.authService.getPosition();
    this.buttonText = this.isNotPM() ? 'Edit' : 'Details';
  }
}
