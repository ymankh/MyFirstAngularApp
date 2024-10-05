import { Component, OnInit } from '@angular/core';
import { Service } from './interfaces/servicesInterfaces';
import { HttpService } from './services/http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  public services: Service[] = [];

  constructor(private http: HttpService) {}

  ngOnInit() {
    this.http.getServices().subscribe((data) => (this.services = data));
  }

 

  title = 'My First Angular App';
}
