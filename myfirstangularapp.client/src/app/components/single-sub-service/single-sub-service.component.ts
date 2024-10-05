import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SubService } from '../../shared/interfaces';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-single-sub-service',
  templateUrl: './single-sub-service.component.html',
  styleUrl: './single-sub-service.component.css',
})
export class SingleSubServiceComponent {
  id = 0;
  service?: SubService;
  constructor(private route: ActivatedRoute, private http: HttpService) {
    console.log('singleSubServiceComponent');
    route.params.subscribe((params) => {
      this.id = params['subServiceID'];
    });
  }
  ngOnInit(): void {
    this.getForecasts();
  }
  getForecasts() {
    this.http.getSingleSubService(this.id)
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
