import { Injectable } from '@angular/core';
import iziToast from 'izitoast';

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  error(message: string) {
    iziToast.error({
      title: 'Error',
      message,
    });
  }
  success(message: string) {
    iziToast.success({
      title: 'OK',
      message,
    });
  }
}
