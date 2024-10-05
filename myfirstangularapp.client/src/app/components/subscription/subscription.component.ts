import { Component } from '@angular/core';
import { HttpService } from '../../services/http.service';
import { ToastService } from '../../shared/toast.service';
import { Plan, User } from '../../shared/interfaces';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrl: './subscription.component.css',
})
export class SubscriptionComponent {
  constructor(
    private http: HttpService,
    private toastService: ToastService,
    private route: ActivatedRoute
  ) {}
  currentUser: User | null = null;

  ngOnInit() {
    this.http
      .getCurrentUser()
      .subscribe((result) => (this.currentUser = result));
  }

  chosePlan(plan: Plan) {
    console.log({
      plan,
      subServiceID: +this.route.snapshot.params['subServiceID'],
      customUserId: this.currentUser!.customUserId,
    });

    if (this.currentUser) {
      this.http
        .createSubscription({
          plan,
          subServiceID: +this.route.snapshot.params['subServiceID'],
          customUserId: this.currentUser.customUserId,
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
