import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeDataService } from '../employee.data.service';
import { CreateEmployee } from '../../../DTO/CreateEmployee';
import { PartnerDTO } from '../../../DTO/PartnerDTO';
import { PositionService } from '../../services/position.data.service';
import { SubdivisionService } from '../../services/subdivision.data.service';
import { PositionDTO } from '../../../DTO/PositionDTO';
import { SubdivisionDTO } from '../../../DTO/SubdivisionDTO';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css'],
  providers: [
    EmployeeDataService,
    PositionService,
    SubdivisionService
  ]
})
export class AddEmployeeComponent implements OnInit {
  employee: CreateEmployee = {
    login: '',
    password: '',
    fullName: '',
    subdivisionId: 0,
    positionId: 0,
    peoplePartnerId: 0
  };
  hrPartners: PartnerDTO[] = [];
  positions: PositionDTO[] = [];
  subdivisions: SubdivisionDTO[] = [];
  dataLoaded: boolean = false;

  constructor(private employeeService: EmployeeDataService, private positionService: PositionService, private subdivisionService: SubdivisionService, private router: Router) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
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
    if (this.hrPartners.length > 0 && this.positions.length > 0 && this.subdivisions.length > 0) {
      this.dataLoaded = true;
    }
  }

  onSubmit(): void {
    this.employeeService.addEmployee(this.employee).subscribe(() => {
      this.router.navigate(['/employees']);
    });
  }
}
