import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { HttpService } from '../../services/http.service';
import { single } from 'rxjs';
import { root } from '../../services/http.service';

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
  public services: Service[] = [];

  constructor(private http: HttpService) {}
  loading = single<boolean>();

  ngOnInit() {
    this.getServices();
  }

  getServices() {
    this.http.getServices().subscribe(
      (result: Service[]) => {
        this.services = result;
      },
      (error: Error) => {
        console.error(error);
      }
    );
  }

  getImageUrl(imagePath: string) {
    return `${root}/${imagePath}`;
  }

  title = 'myfirstangularapp.client';
}
