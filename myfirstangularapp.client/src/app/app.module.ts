import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SubServicesComponent } from './components/sub-services/sub-services.component';
import { HomeComponent } from './components/home/home.component';
import { SingleSubServiceComponent } from './components/single-sub-service/single-sub-service.component';

@NgModule({
  declarations: [
    AppComponent,
    SubServicesComponent,
    HomeComponent,
    SingleSubServiceComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
