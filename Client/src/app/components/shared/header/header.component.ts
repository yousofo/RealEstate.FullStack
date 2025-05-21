import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  effect,
  inject,
  OnInit,
  signal,
} from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
// import { LoginService } from '../../services/popups/login/login.service';
import { ButtonModule } from 'primeng/button';
import { AuthService } from '../../../services/auth/auth.service';
// import { SearchComponent } from '../search/search.component';
import { MenuModule } from 'primeng/menu';
import { MenuItem } from 'primeng/api';
import { FormsModule } from '@angular/forms';
import { FloatLabel } from 'primeng/floatlabel';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputTextModule } from 'primeng/inputtext';
import { ScrollService } from '../../../services/scroll/scroll.service';
import { UiStateService } from '../../../services/UiState/ui-state.service';
import { ProgressBar } from 'primeng/progressbar';
import { LoadingService } from '../../../services/loading/loading.service';
// import { SearchService } from '../../services/search/search.service';
@Component({
  selector: 'app-header',
  standalone: true,
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    RouterLink,
    RouterLinkActive,
    ButtonModule,
    MenuModule,
    FormsModule,
    FloatLabel,
    InputGroupModule,
    InputGroupAddonModule,
    InputTextModule,
    ProgressBar,
  ],
  host: {
    onscroll: 'onScroll()',
  },
})
export class HeaderComponent implements OnInit {
  isDiscount: boolean = false;
  items: MenuItem[] | undefined;

  visible = signal(true);

  scrollService = inject(ScrollService);
  UiStateService = inject(UiStateService);
  authService = inject(AuthService);
  loadingService = inject(LoadingService);
  router = inject(Router);
  cd = inject(ChangeDetectorRef);
  // searchInput: string = '';

  // loginService = inject(LoginService);
  // searchService = inject(SearchService);
  constructor() {
    effect(() => {
      this.items = [
        {
          label: 'Options',
          items: [
            // {
            //   label: 'account',
            //   icon: 'pi pi-cog',
            //   routerLink: '/account',
            // },
            {
              label: 'logout',
              icon: 'pi pi-sign-out',
              visible: this.authService.isAuthenticated(),
              command: () => {
                this.authService.logout();
              },
            },
            {
              label: 'login',
              icon: 'pi pi-sign-in',
              visible: !this.authService.isAuthenticated(),
              command: () => {
                this.authService.openDieloag();
              },
            },
            {
              label: 'sign up',
              icon: 'pi pi-user-plus',
              visible: !this.authService.isAuthenticated(),
              routerLink: '/sign-up',
            },
          ],
        },
      ];
    });
  }
  ngOnInit() {
    console.log('from header');
  }

  addProperty(e: Event) {
    e.preventDefault();

    if (!this.authService.isAuthenticated()) {
      this.authService.dialogVisible.set(true);
      return;
    }

    this.router.navigate(['/add-property']);
  }
}
