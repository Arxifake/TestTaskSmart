import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { LeaveRequest } from "../../DTO/LeaveRequest";
import { PaginationDTO } from "../../DTO/PaginationDTO";
import { Observable } from "rxjs";

@Injectable()
export class LeaveRequestDataService {
  private url = 'api/LeaveRequest';

  constructor(private http: HttpClient) { }

  getLeaveRequests(sortBy: string, sortType: string, searchString: string, pageNumber: number, id: number | null): Observable<PaginationDTO<LeaveRequest>> {
    let params: any = { sortBy: sortBy, sortType: sortType, searchString: searchString, pageNumber: pageNumber };

    if (id !== null) {
      params.id = id;
    }

    return this.http.get(this.url, { params: params });
  }

  getLeaveReuestById(id: number): Observable<LeaveRequest> {
    return this.http.get<LeaveRequest>(`${this.url}/${id}`);
  }

  createLeaveRequest(leaveRequest: any): Observable<any> {
    return this.http.post(this.url, leaveRequest);
  }

  submitLeaveRequest(id:number): Observable<any> {
    return this.http.post(this.url + '/submit', id);
  }

  cancelLeaveRequest(id: number): Observable<any> {
    return this.http.post(this.url + '/cancel', id);
  }

  updateLeaveRequest(leaveRequest: any): Observable<any> {
    return this.http.put(`${this.url}/${leaveRequest.id}`, leaveRequest);
  }
}
