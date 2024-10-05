import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpService } from '../../services/http.service';
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
  selector: 'app-sub-services',
  templateUrl: './sub-services.component.html',
  styleUrl: './sub-services.component.css',
})
export class SubServicesComponent {
  id: number = 0;
  constructor(private route: ActivatedRoute, private http: HttpService) {
    this.id = this.route.snapshot.params['serviceID'];
  }

  ngOnInit() {
    this.http.getSingleServices(this.id).subscribe(
      (result: Service) => {
        this.forecasts = result.subServices;
      },
      (error: Error) => {
        console.error(error);
      }
    );
  }
  forecasts: SubService[] = [];
}
