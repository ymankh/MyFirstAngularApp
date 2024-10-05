import { Component } from '@angular/core';
import { HttpService } from '../../services/http.service';
import { ToastService } from '../../shared/toast.service';
import { Plan } from '../../shared/interfaces';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrl: './subscription.component.css',
})
export class SubscriptionComponent {
  constructor(private http: HttpService, private toastService: ToastService) {}

  chosePlan(plan: Plan) {
    if (this.http.IsLoggedIn) {
      this.http
        .createSubscription({
          plan,
          subServiceID: 1,
          customUserId: 1,
        })
        .subscribe(
          (result) => {
            this.toastService.success('Subscription Created');
          },
          (error) => {
            this.toastService.error(
              'Subscription Failed, are you shore you are logged in?'
            );
          }
        );
    } else {
      this.toastService.error('You must be logged in to create a subscription');
    }
  }
}
