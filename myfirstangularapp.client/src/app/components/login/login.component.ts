import { Component, ViewChild, OnInit } from '@angular/core';
import { HttpService } from '../../services/http.service';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastService } from '../../shared/toast.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule, FormsModule],
})
export class LoginComponent implements OnInit {
  constructor(
    private http: HttpService,
    private router: Router,
    private toastService: ToastService
  ) {}

  ngOnInit(): void {}

  email = '';
  password = '';

  onSubmit() {
    this.http.login(this.email, this.password).subscribe(
      (result) => {
        localStorage.setItem('token', result.token);
        this.toastService.success('Login Successful');
        this.router.navigate(['']);
      },
      (error) => {
        this.toastService.error('Login Failed');
      }
    );
  }
}
