import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaginationDTO } from '../../DTO/PaginationDTO';
import { PublicEmployeeDTO } from '../../DTO/EmployeePublicDTO';
import { CreateEmployee } from '../../DTO/CreateEmployee';
import { PartnerDTO } from '../../DTO/PartnerDTO';
import { EmployeeProject } from '../../DTO/EmployeeProject';

@Injectable()
export class EmployeeDataService {
  private url = 'api/employees';

  constructor(private http: HttpClient) { }

  getEmployees(sortBy: string, sortType: string, searchString: string, pageNumber: number): Observable<PaginationDTO<PublicEmployeeDTO>> {
    let params = { sortBy: sortBy, sortType: sortType, searchString: searchString, pageNumber: pageNumber };

    return this.http.get(this.url, { params: params });
  }

  changeStatus(id: number) {
    return this.http.post(this.url + "/status",id);
  }

  addEmployee(employee: CreateEmployee): Observable<any> {
    return this.http.post(this.url, employee);
  }

  updateEmployee(employee: any): Observable<any> {
    return this.http.put(`${this.url}/${employee.id}`, employee);
  }

  getPartners(): Observable<any> {
    return this.http.get(this.url+"/partners")
  }

  getEmployeeById(id: number): Observable<any> {
    return this.http.get<any>(`${this.url}/${id}`);
  }

  getEmployeeToEdit(id: number): Observable<any> {
    return this.http.get<any>(this.url + "/edit" + id);
  }

  assignToProject(empProj: EmployeeProject) {
    return this.http.post(this.url + "/assign", empProj);
  }
}
