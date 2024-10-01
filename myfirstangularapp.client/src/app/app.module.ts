import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SubServicesComponent } from './components/sub-services/sub-services.component';
import { HomeComponent } from './components/home/home.component';
import { SingleSubServiceComponent } from './components/single-sub-service/single-sub-service.component';
import { SubServicesDetailesComponent } from './components/sub-services-detailes/sub-services-detailes.component';
import { SubsecriptionComponent } from './components/subsecription/subsecription.component';

@NgModule({
  declarations: [
    AppComponent,
    SubServicesComponent,
    HomeComponent,
    SingleSubServiceComponent,
    SubServicesDetailesComponent,
    SubsecriptionComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
