import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sub-services',
  templateUrl: './sub-services.component.html',
  styleUrl: './sub-services.component.css',
})
export class SubServicesComponent {
  id: number = 0;
  constructor(private route: ActivatedRoute) {
    this.id = this.route.snapshot.params['serviceID'];
  }
}
