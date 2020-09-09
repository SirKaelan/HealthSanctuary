import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { map, tap, switchMap } from 'rxjs/operators';
import jwt_decode from 'jwt-decode';

import { environment } from '../../environments/environment';

interface AccessToken {
  'access_token': string;
  'refresh_token': string;
  'expires_in': number;
  'token_type': string;
  'scope': string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokenEndpoint = `${environment.healthSanctuaryApiRoot}/connect/token`;
  private registerEndpoint = `${environment.healthSanctuaryApiRoot}/api/users/register`;

  accessToken$ = new BehaviorSubject<string>('');
  userId$ = this.accessToken$.pipe<string>(
    map(token => token ? jwt_decode(token).sub : '')
  );

  constructor(private http: HttpClient) { }

  register(username: string, password: string): Observable<string> {
    return this.http.post(this.registerEndpoint, { username, password }).pipe(
      switchMap(() => this.login(username, password))
    );
  }

  login(username: string, password: string): Observable<string> {
    const params = new HttpParams()
      .set('username', username)
      .set('password', password)
      .set('grant_type', 'password')
      .set('client_id', 'ro.client');

    const headers = new HttpHeaders()
      .set('Content-Type', 'application/x-www-form-urlencoded');

    return this.http.post<AccessToken>(this.tokenEndpoint, params, { headers } )
      .pipe(
        map(res => res.access_token),
        tap(token => this.accessToken$.next(token)),
      );
  }

  logout() {
    this.accessToken$.next('');
  }
}
