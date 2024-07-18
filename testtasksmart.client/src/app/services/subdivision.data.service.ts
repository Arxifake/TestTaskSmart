import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SubdivisionDTO } from '../../DTO/SubdivisionDTO';

@Injectable({
  providedIn: 'root'
})
export class SubdivisionService {
  private url = 'api/subdivisions';

  constructor(private http: HttpClient) { }

  getSubdivisions(): Observable<any> {
    return this.http.get<SubdivisionDTO>(this.url);
  }
}
