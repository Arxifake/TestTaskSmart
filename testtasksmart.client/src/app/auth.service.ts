import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';
import { AuthResponse } from '../DTO/AuthResponse';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userIdKey = 'userId';
  private positionKey = 'position';

  constructor(private http: HttpClient, private cookieService: CookieService, private router: Router) { }

  login(login: string, password: string): Observable<AuthResponse> {
    return this.http.post<AuthResponse>('/api/login', { login, password }).pipe(
      tap(response => {
        this.cookieService.set(this.userIdKey, response.id);
        this.cookieService.set(this.positionKey, response.position);
      }),
      catchError((error: HttpErrorResponse) => {
        return throwError(() => new Error(error.error.message || 'Server error'));
      })
    );
  }


  logout(): void {
    this.cookieService.delete(this.userIdKey);
    this.cookieService.delete(this.positionKey);
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    return this.cookieService.check(this.userIdKey) && this.cookieService.check(this.positionKey);
  }

  getUserId(): number {
    const userId = this.cookieService.get(this.userIdKey);
    return parseInt(userId, 10);
  }

  getPosition(): string {
    return this.cookieService.get(this.positionKey);
  }
}
