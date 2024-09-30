import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

interface SubService {
  subServiceID: number;
  subServiceName: string;
  subServiceDescription: string;
  subServiceImage: string;
  serviceID: number;
}
interface WeatherForecast {
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
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http
      .get<WeatherForecast[]>('https://localhost:7049/api/Services')
      .subscribe(
        (result: WeatherForecast[]) => {
          this.forecasts = result;
        },
        (error: Error) => {
          console.error(error);
        }
      );
  }

  title = 'myfirstangularapp.client';
}
