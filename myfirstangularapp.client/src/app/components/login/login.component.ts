import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgModel } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule, FormsModule],
})
export class LoginComponent {
  constructor(private http: HttpService) {}

  email = '';
  password = '';
  onSubmit() {
    this.http.login(this.email, this.password).subscribe((result) => {
      localStorage.setItem('token', result.token);
    });
  }
}
