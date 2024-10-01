import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SubService } from '../../shared/interfaces';

@Component({
  selector: 'app-single-sub-service',
  templateUrl: './single-sub-service.component.html',
  styleUrl: './single-sub-service.component.css',
})
export class SingleSubServiceComponent {
  service?: SubService;
  constructor(private route: ActivatedRoute, private http: HttpClient) {
    route.params.subscribe((params) => {
      this.service = params['serviceID'];
    });
  }
  onInit() {
    console.log('singleSubServiceComponent');
    
  }
  getForecasts() {
    this.http
      .get<SubService>(`https://localhost:7049/api/SubServices/${this.service}`)
      .subscribe(
        (result: SubService) => {
          this.service = result;
        },
        (error: Error) => {
          console.error(error);
        }
      );
  }
}
