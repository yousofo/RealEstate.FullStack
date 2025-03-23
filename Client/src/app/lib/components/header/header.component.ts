import { Component, inject, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { LoginService } from '../../services/popups/login/login.service';
import { ButtonModule } from 'primeng/button';
import { AuthService } from '../../services/auth/auth.service';
import { SearchComponent } from '../search/search.component';
import { MenuModule } from 'primeng/menu';
import { MenuItem } from 'primeng/api';
import { FormsModule } from '@angular/forms';
import { FloatLabel } from 'primeng/floatlabel';

@Component({
  selector: 'app-header',
  standalone: true,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  imports: [
    RouterLink,
    RouterLinkActive,
    ButtonModule,
    MenuModule,
    FormsModule,
    FloatLabel,
  ],
})
export class HeaderComponent implements OnInit {
  isDiscount: boolean = false;
  items: MenuItem[] | undefined;
  searchInput: string = '';
  
  loginService = inject(LoginService);
  authService = inject(AuthService);

  ngOnInit() {
    console.log('from header');
    this.items = [
      {
        label: 'Options',
        items: [
          {
            label: 'Refresh',
            icon: 'pi pi-refresh',
          },
          {
            label: 'Export',
            icon: 'pi pi-upload',
          },
        ],
      },
    ];
  }
}
