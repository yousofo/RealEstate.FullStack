//import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
//import { AppModule } from './app/app.module';
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideHttpClient } from '@angular/common/http';
import { appConfig } from './app.config';

import { register } from 'swiper/element/bundle';
register();
bootstrapApplication(AppComponent, appConfig).catch((err) =>
  console.error(err)
);

//platformBrowserDynamic().bootstrapModule(AppModule, {
//  ngZoneEventCoalescing: true,
//})
//  .catch(err => console.error(err));

//