import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgModel } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule, FormsModule],
})
export class LoginComponent {
  constructor(private http: HttpClient) {}

  email = '';
  password = '';
  onSubmit() {
    this.http
      .post<{ token: string }>(
        'http://localhost:5074/api/Auth/login',
        {
          email: this.email,
          password: this.password,
        },
        { headers: this.headers }
      )
      .subscribe((result) => {
        localStorage.setItem('token', result.token);
      });
  }

  getCurrentUser() {
    return this.http.get('').subscribe((result) => {
      console.log(result);
    });
  }
  get headers() {
    return new HttpHeaders({
      'Content-Type': 'application/json', 
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });
  }
}
