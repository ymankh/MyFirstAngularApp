import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SubService, type Service } from '../interfaces/servicesInterfaces';
import { User } from '../shared/interfaces';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  root = 'http://localhost:5074/api';
  constructor(private readonly http: HttpClient) {}

  getServices(): Observable<Service[]> {
    return this.http.get<Service[]>(this.root + '/Services');
  }
  addService(formData: FormData): Observable<Service> {
    return this.http.post<Service>(this.root + '/services', formData);
  }

  getSingleSubService(id: number): Observable<SubService> {
    return this.http.get<SubService>(
      `http://localhost:5074/api/SubServices/${id}`
    );
  }

  login(email: string, password: string): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(
      this.root + '/api/Auth/login',
      { email, password },
      { headers: this.headers }
    );
  }

  getCurrentUser(): Observable<User> {
    return this.http.get<User>(this.root + '/api/Auth/GetUser');
  }

  get headers() {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });
  }
}
