import { Injectable } from "@angular/core";
import { Project } from "../../DTO/Project";
import { PaginationDTO } from "../../DTO/PaginationDTO";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class ProjectDataService {

  private url = 'api/Project';

  constructor(private http: HttpClient) { }

  getProjects(sortBy: string, sortType: string, searchString: string, pageNumber: number, id: number | null): Observable<PaginationDTO<Project>> {
    let params: any = { sortBy: sortBy, sortType: sortType, searchString: searchString, pageNumber: pageNumber };

    if (id !== null) {
      params.id = id;
    }

    return this.http.get(this.url, { params: params });
  }

  changeStatus(id: number) {
    return this.http.post(this.url + "/status", id);
  }
}
