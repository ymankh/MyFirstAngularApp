import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  type SubService,
  type Service,
} from '../interfaces/servicesInterfaces';
import {
  type User,
  type Subscription,
  CreateSubscription,
} from '../shared/interfaces';

export let root = 'http://localhost:5094';

let apiRoot = root + '/api';
@Injectable({
  providedIn: 'root',
})
export class HttpService {
  constructor(private readonly http: HttpClient) {}

  getServices(): Observable<Service[]> {
    return this.http.get<Service[]>(apiRoot + '/Services');
  }
  addService(formData: FormData): Observable<Service> {
    return this.http.post<Service>(apiRoot + '/services', formData);
  }

  updateService(formData: FormData, id: number): Observable<Service> {
    return this.http.put<Service>(apiRoot + `/services/${id}`, formData);
  }

  getSingleServices(id: number): Observable<Service> {
    let link = `${apiRoot}/Services/${id}`;
    return this.http.get<Service>(link);
  }

  getSingleSubService(id: number): Observable<SubService> {
    return this.http.get<SubService>(`${apiRoot}/SubServices/${id}`);
  }

  login(email: string, password: string): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(apiRoot + '/Auth/login', {
      email: email.toLocaleLowerCase().trim(),
      password,
    });
  }

  getCurrentUser(): Observable<User> {
    return this.http.get<User>(apiRoot + '/Auth/GetUser', {
      headers: this.headers,
    });
  }

  getSubscriptions(): Observable<Subscription[]> {
    return this.http.get<Subscription[]>(
      apiRoot + '/Subscription/GetSubscriptions',
      {
        headers: this.headers,
      }
    );
  }

  createSubscription(
    subscription: CreateSubscription
  ): Observable<Subscription> {
    return this.http.post<Subscription>(
      apiRoot + '/Subscription/CreateSubscription',
      subscription,
      {
        headers: this.headers,
      }
    );
  }

  get headers() {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });
  }
  get IsLoggedIn() {
    return localStorage.getItem('token') !== null;
  }
}
