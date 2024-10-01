import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

interface SubService {
  subServiceID: number;
  subServiceName: string;
  subServiceDescription: string;
  subServiceImage: string;
  serviceID: number;
}
interface Service {
  serviceID: number;
  serviceName: string;
  serviceDescription: string;
  serviceImage: string;
  subServices: SubService[];
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  public forecasts: Service[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getServices();
  }

  getServices() {
    this.http
      .get<Service[]>('https://localhost:7049/api/Services')
      .subscribe(
        (result: Service[]) => {
          this.forecasts = result;
        },
        (error: Error) => {
          console.error(error);
        }
      );
  }

  title = 'myfirstangularapp.client';
}
