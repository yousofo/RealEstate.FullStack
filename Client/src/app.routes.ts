import { Routes } from '@angular/router';
import { AboutUsPageComponent } from './app/pages/about-us-page/about-us-page.component';
import { HomePageComponent } from './app/pages/home-page/home-page.component';
import { PropertyDetailsPageComponent } from './app/pages/property-details-page/property-details-page.component';
import { PropertiesPageComponent } from './app/pages/properties-page/properties-page.component';
import { SignUpPageComponent } from './app/pages/sign-up-page/sign-up-page.component';
import { UserPageComponent } from './app/pages/user-page/user-page.component';
import { NotFoundPageComponent } from './app/pages/not-found-page/not-found-page.component';
import { ChatAiPageComponent } from './app/pages/chat-ai-page/chat-ai-page.component';

export const routes: Routes = [
  {
    path: '',
    component: HomePageComponent,
  },
  {
    path: 'about-us',
    component: AboutUsPageComponent,
  },
  {
    path: 'chat-ai',
    component: ChatAiPageComponent,
  },
  {
    path: 'properties',
    component: PropertiesPageComponent,
  },
  {
    path: 'property/:id',
    component: PropertyDetailsPageComponent,
  },
  {
    path: 'sign-up',
    component: SignUpPageComponent,
  },
  {
    path: 'users/user/:id',
    component: UserPageComponent,
  },
  {
    path: '**',
    component: NotFoundPageComponent,
  },
];
