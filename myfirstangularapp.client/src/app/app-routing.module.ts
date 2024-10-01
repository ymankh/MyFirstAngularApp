import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SubServicesComponent } from './components/sub-services/sub-services.component';
import { SingleSubServiceComponent } from './components/single-sub-service/single-sub-service.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', component: HomeComponent},
  {path: 'sub-services/:serviceID', component: SubServicesComponent},
  {path: 'sub-services/:serviceID/:subServiceID', component: SingleSubServiceComponent},
  // {path: }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
