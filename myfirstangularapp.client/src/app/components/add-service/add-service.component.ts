import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpService } from '../../services/http.service';
import { Router } from '@angular/router';
import { ToastService } from '../../shared/toast.service';

@Component({
  selector: 'app-add-service',
  templateUrl: './add-service.component.html',
  styleUrl: './add-service.component.css',
})
export class AddServiceComponent {
  serviceForm: FormGroup;
  selectedFile: File | null = null;

  constructor(
    private fb: FormBuilder,
    private http: HttpService,
    private router: Router,
    private toast: ToastService
  ) {
    this.serviceForm = this.fb.group({
      serviceName: ['', Validators.required],
      serviceDescription: ['', Validators.required],
      serviceImage: [null, Validators.required],
    });
  }

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0];
    this.serviceForm.patchValue({ serviceImage: this.selectedFile });
  }

  onSubmit(): void {
    if (this.serviceForm.invalid) {
      return;
    }

    const formData = new FormData();
    formData.append('ServiceName', this.serviceForm.get('serviceName')?.value);
    formData.append(
      'ServiceDescription',
      this.serviceForm.get('serviceDescription')?.value
    );
    if (this.selectedFile) {
      formData.append('ServiceImage', this.selectedFile);
    }

    this.http.addService(formData).subscribe(
      (response) => {
        console.log('Service created successfully!', response);
        this.toast.success('Service created successfully!');
        this.router.navigate(['/']);
      },
      (error) => {
        console.error('Error creating service:', error);
      }
    );
  }
}
