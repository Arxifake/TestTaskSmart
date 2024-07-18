import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeDataService } from '../employee.data.service';
import { PartnerDTO } from '../../../DTO/PartnerDTO';
import { PositionDTO } from '../../../DTO/PositionDTO';
import { SubdivisionDTO } from '../../../DTO/SubdivisionDTO';
import { EditEmployee } from '../../../DTO/EditEmployee';
import { PositionService } from '../../services/position.data.service';
import { SubdivisionService } from '../../services/subdivision.data.service';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css'],
  providers: [
    EmployeeDataService,
    PositionService,
    SubdivisionService
  ]
})
export class EditEmployeeComponent implements OnInit {
  employee: EditEmployee = {
    id: 0,
    fullName: '',
    positionId: 0,
    subdivisionId: 0,
    peoplePartnerId: 0,
    status: false,
    balance: 0
  };
  hrPartners: PartnerDTO[] = [];
  positions: PositionDTO[] = [];
  subdivisions: SubdivisionDTO[] = [];
  dataLoaded: boolean = false;
  employeeId: number;

  constructor(
    private route: ActivatedRoute,
    private employeeService: EmployeeDataService,
    private positionService: PositionService,
    private subdivisionService: SubdivisionService,
    private router: Router,
    public authService: AuthService
  ) {
    this.employeeId = this.route.snapshot.params['id'];      
  }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.employeeService.getEmployeeToEdit(this.employeeId).subscribe(employee => {
      this.employee = employee;
      this.checkDataLoaded();
    });

    this.employeeService.getPartners().subscribe(partners => {
      this.hrPartners = partners;
      this.checkDataLoaded();
    });

    this.positionService.getPositions().subscribe(positions => {
      this.positions = positions;
      this.checkDataLoaded();
    });

    this.subdivisionService.getSubdivisions().subscribe(subdivisions => {
      this.subdivisions = subdivisions;
      this.checkDataLoaded();
    });
  }

  checkDataLoaded(): void {
    if (
      this.employee.fullName &&
      this.hrPartners.length > 0 &&
      this.positions.length > 0 &&
      this.subdivisions.length > 0
    ) {
      this.dataLoaded = true;
    }
  }

  isPM(): boolean {
    return this.authService.getPosition() === 'PM';
  }

  onSubmit(): void {
    this.employeeService.updateEmployee(this.employee).subscribe(() => {
      this.router.navigate(['/employees']);
    });
  }
}
