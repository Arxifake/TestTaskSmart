import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { PaginationDTO } from "../../DTO/PaginationDTO";
import { Observable } from "rxjs";
import { ApprovalRequest } from "../../DTO/ApprovalRequest";

@Injectable()
export class ApprovalRequestDataService {
  private url = 'api/ApprovalRequest';

  constructor(private http: HttpClient) { }

  getApprovalRequests(sortBy: string, sortType: string, searchString: string, pageNumber: number): Observable<PaginationDTO<ApprovalRequest>> {
    let params = { sortBy: sortBy, sortType: sortType, searchString: searchString, pageNumber: pageNumber };

    return this.http.get(this.url, { params: params });
  }

  getApprovalReuestById(id: number): Observable<ApprovalRequest> {
    return this.http.get<ApprovalRequest>(`${this.url}/${id}`);
  }

  approveRequest(id: number): Observable<any> {
    return this.http.post(this.url + '/approve', id);
  }

  rejectRequest(id: number): Observable<any> {
    return this.http.post(this.url + '/reject', id);
  }
}
