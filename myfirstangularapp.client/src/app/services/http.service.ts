import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { type Service } from '../interfaces/servicesInterfaces';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  root = 'http://localhost:5074/api';
  constructor(private readonly http: HttpClient) {}

  getServices(): Observable<Service[]> {
    return this.http.get<Service[]>(this.root + '/Services');
  }
}
