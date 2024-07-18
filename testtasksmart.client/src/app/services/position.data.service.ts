import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PositionDTO } from '../../DTO/PositionDTO';

@Injectable({
  providedIn: 'root'
})
export class PositionService {
  private url = 'api/positions';

  constructor(private http: HttpClient) { }

  getPositions(): Observable<any> {
    return this.http.get<PositionDTO>(this.url);
  }
}
