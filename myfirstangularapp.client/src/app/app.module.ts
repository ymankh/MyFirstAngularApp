import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SubServicesComponent } from './components/sub-services/sub-services.component';
import { HomeComponent } from './components/home/home.component';
import { SingleSubServiceComponent } from './components/single-sub-service/single-sub-service.component';
import { SubServicesDetailsComponent } from './components/sub-services-details/sub-services-details.component';
import { RegisterComponent } from './components/register/register.component';
import { SubscriptionComponent } from './components/subscription/subscription.component';
import { HeaderComponent } from './components/header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    SubServicesComponent,
    HomeComponent,
    SingleSubServiceComponent,
    SubServicesDetailsComponent,
    RegisterComponent,
    SubscriptionComponent,
    HeaderComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
