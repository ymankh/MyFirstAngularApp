import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SubServicesComponent } from './components/sub-services/sub-services.component';
import { SingleSubServiceComponent } from './components/single-sub-service/single-sub-service.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { SubscriptionComponent } from './components/subscription/subscription.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', component: HomeComponent},
  {path: 'sub-services/:serviceID', component: SubServicesComponent},
  {path: 'sub-services/:serviceID/:subServiceID', component: SingleSubServiceComponent},
  {path: "login", component: LoginComponent},
  {path: "subscription/:subServiceID", component:SubscriptionComponent },
  {path: "register", component: RegisterComponent},
  {path: "**", redirectTo: ""}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
