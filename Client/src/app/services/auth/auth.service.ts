import { inject, Injectable, signal } from '@angular/core';
import { IAuthState, IUser } from '../../types/auth';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { LoginService } from '../popups/login/login.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private _authState = signal<IAuthState>({
    user: null,
    loading: false,
    error: '',
    isAuthenticated: false,
  });

  private httpClient = inject(HttpClient);
  private loginService = inject(LoginService);

  get authState(): IAuthState {
    return this._authState();
  }

  reset() {
    this._authState.set({
      user: null,
      loading: false,
      error: '',
      isAuthenticated: false,
    });
  }

  /**
   * 
   * .prop(e=>e.roles.role.name)
   */

  login(email: string, password: string) {
    console.log(email, password);
    this._authState.set({
      user: null,
      loading: true,
      error: '',
      isAuthenticated: false,
    });

    this.httpClient
      .post<IUser>(`${environment.apiUrl}/api/auth/login`, { email, password },{
        withCredentials: true,
      })
      .subscribe({
        next: (user) => {
          console.log(user);
          this._authState.set({
            user,
            loading: false,
            error: '',
            isAuthenticated: true,
          });
          
          this.loginService.hide();
        },
        error: (error) => {
          console.error(error);
          this._authState.set({
            user: null,
            loading: false,
            error: error.message,
            isAuthenticated: false,
          });
        },
      });
  }

  constructor() {}
}
