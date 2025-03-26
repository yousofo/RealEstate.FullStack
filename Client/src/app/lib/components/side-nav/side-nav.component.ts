import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { NgIf } from '@angular/common';
import { PanelMenu } from 'primeng/panelmenu';
import { MenuItem, MessageService } from 'primeng/api';

@Component({
  selector: 'app-side-nav',
  standalone: true,
  templateUrl: './side-nav.component.html',
  styleUrl: './side-nav.component.css',
  imports: [RouterLink, RouterLinkActive, NgIf, PanelMenu],
  providers: [MessageService],
})
export class SideNavComponent {
  authService = inject(AuthService);
  router = inject(Router);

  items!: MenuItem[];

  ngOnInit() {
    this.items = [
      {
        label: 'Router',
        icon: 'pi pi-palette',
        items: [
          {
            label: 'Installation',
            icon: 'pi pi-eraser',
            route: '/installation',
          },
          {
            label: 'Configuration',
            icon: 'pi pi-heart',
            route: '/configuration',
          },
        ],
      },
      {
        label: 'Programmatic',
        icon: 'pi pi-link',
        command: () => {
          this.router.navigate(['/installation']);
        },
      },
      {
        label: 'External',
        icon: 'pi pi-home',
        items: [
          {
            label: 'Angular',
            icon: 'pi pi-star',
            url: 'https://angular.io/',
          },
          {
            label: 'Vite.js',
            icon: 'pi pi-bookmark',
            url: 'https://vitejs.dev/',
          },
        ],
      },
    ];
  }
}
