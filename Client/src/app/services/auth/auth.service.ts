import { computed, inject, Injectable, Signal, signal } from '@angular/core';
import { IAuthState, ISignupRequest, IUser } from '../../types/auth';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Router } from '@angular/router';
import { finalize, tap } from 'rxjs';
import { storage } from '../../utils/storage/storage.utils';
// import { LoginService } from '../popups/login/login.service';

//dev user
const DEV_USER: IUser = {
  id: 'id',
  email: 'H5w0S@example.com',
  lastName: 'User',
  firstName: 'Dev',
  token: 'token',
  roles: ['Owner'],
  expiresIn: 0,
  refreshToken: '',
  refreshTokenExpirationDate: '',
  // image: '',
  // phone: '',
  // address: '',
  // description: '',
};

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  user = signal<IUser | null>(storage.getItem('appSession')?.user ?? null);

  isAuthenticated = computed(() => {
    return !!this.user();
  });

  dialogVisible = signal(false);

  private httpClient = inject(HttpClient);
  private router = inject(Router);

  constructor() {
    this.validateToken();
  }

  public isOwner = computed(() => {
    console.log('[computed] checking isOwner', this.user()?.roles);
    return this.user()?.roles.includes('Owner') ?? false;
  });

  logout() {
    //clear set cookies from browser
    // const observable = this.httpClient.post<IUser>(
    //   `${environment.apiUrl}/api/account/logout`,
    //   null
    // );

    // observable.subscribe({
    //   next: (user) => {
    //     console.log(user);
    //   },
    //   error: (error) => {
    //     console.error(error);
    //   },
    //   complete: () => {
    //     // this.loadingService.stop();
    //   },
    // });

    // this.router.navigate(['/login']);
    storage.removeItem('appSession');
    this.user.set(null);
    this.router.navigate(['/']);
    this.dialogVisible.set(false);
  }

  signup(signup: ISignupRequest) {
    return this.httpClient.post<IUser>(
      `${environment.apiUrl}/api/auth/signup`,
      signup
    );
  }

  login(email: string, password: string) {
    console.log(email, password);

    // this.loadingService.start();

    return this.httpClient
      .post<IUser>(`${environment.apiUrl}/api/auth/login`, {
        email,
        password,
      })
      .pipe(
        tap({
          next: (user) => {
            if (user.token) {
              this.router.navigate(['/']);
              this.user.set(user);

              this.dialogVisible.set(false);

              storage.setItem('appSession', {
                user: user,
                token: user.token,
              });
            }
          },
        })
      );
  }

  loadUser() {
    // this.loadingService.start();

    const observable = this.httpClient.get<IUser>(
      `${environment.apiUrl}/api/auth/validate-token`
    );

    observable.subscribe({
      next: (user) => {
        console.log('load user', user);
        if (!user?.roles.includes('Admin') && !user?.roles.includes('Owner')) {
          throw new Error('Access Denied');
        }

        if (!user) {
          this.router.navigate(['/login']);
          return;
        }

        this.user.set(user);
      },
      error: (error) => {
        this.router.navigate(['/login']);
      },
      complete: () => {
        document.getElementById('initial-splash')?.remove();
      },
    });

    return observable;
  }

  validateToken() {
    this.httpClient
      .get(`${environment.apiUrl}/api/auth/validate-token`)
      .subscribe({
        error: (error) => {
          console.log('validate token error', error);
          this.user.set(null);
          storage.removeItem('appSession');
        },
      });
  }

  openDieloag() {
    if (this.isAuthenticated()) return;

    this.dialogVisible.set(true);
  }

  closeDialog() {
    this.dialogVisible.set(false);
  }
}
