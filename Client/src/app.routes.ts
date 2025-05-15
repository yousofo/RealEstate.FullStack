import { Routes } from '@angular/router';
import { AboutUsPageComponent } from './app/pages/about-us-page/about-us-page.component';
import { HomePageComponent } from './app/pages/home-page/home-page.component';
import { PropertyDetailsPageComponent } from './app/pages/property-details-page/property-details-page.component';
import { PropertiesPageComponent } from './app/pages/properties-page/properties-page.component';
import { SignUpPageComponent } from './app/pages/sign-up-page/sign-up-page.component';
import { UserPageComponent } from './app/pages/user-page/user-page.component';
import { NotFoundPageComponent } from './app/pages/not-found-page/not-found-page.component';
import { ChatAiPageComponent } from './app/pages/chat-ai-page/chat-ai-page.component';
import { AdminPropertiesPageComponent } from './app/pages/admin/admin-properties-page/admin-properties-page.component';
import { AdminUsersPageComponent } from './app/pages/admin/admin-users-page/admin-users-page.component';
import { AdminIssuesPageComponent } from './app/pages/admin/admin-issues-page/admin-issues-page.component';
import { AddPropertyPageComponent } from './app/pages/add-property-page/add-property-page.component';

export const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        title: 'Home',
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
        children: [
          {
            path: '',
            title: 'Properties',
            component: PropertiesPageComponent,
          },
          {
            path: 'property/:id',
            component: PropertyDetailsPageComponent,
          },
        ],
      },
      {
        path: 'add-property',
        component: AddPropertyPageComponent,
        title: 'Add Property',
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
        path: 'admin/properties',
        component: AdminPropertiesPageComponent,
      },
      {
        path: 'admin/users',
        component: AdminUsersPageComponent,
      },
      {
        path: 'admin/issues',
        component: AdminIssuesPageComponent,
      },
    ],
  },
  {
    path: '**',
    component: NotFoundPageComponent,
  },
];
