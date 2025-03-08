import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './lib/components/header/header.component';
import { FooterComponent } from './lib/components/footer/footer.component';
import { HomeComponent } from './pages/home/home.component';
import { SearchComponent } from './lib/components/search/search.component';
import { PropertyCardComponent } from './lib/components/property-card/property-card.component';

// @NgModule({
//   declarations: [
//     AppComponent,
//     HeaderComponent,
//     FooterComponent,
//     HomeComponent,
//     SearchComponent,
//     PropertyCardComponent
//   ],
//   imports: [
//     BrowserModule, HttpClientModule,
//     AppRoutingModule
//   ],
//   providers: [],
//   bootstrap: [AppComponent]
// })
// export class AppModule { }
