import { inject, Injectable, signal } from '@angular/core';
import { IAuthState, IUser } from '../../types/auth';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _authState = signal<IAuthState>({ user: null, loading: false, error: '', isAuthenticated: false });
  private httpClient = inject(HttpClient);


  get authState(): IAuthState {
    return this._authState();
  }
  

  loginAsync(email: string, password: string) {
    this._authState.set({ user: null, loading: true, error: '', isAuthenticated: false });

    this.httpClient.post<IUser>('/api/auth/login', { email, password }).subscribe({
      next: (user) => {
        console.log(user);
        this._authState.set({ user, loading: false, error: '', isAuthenticated: true });
      },
      error: (error) => {
        console.error(error);
        this._authState.set({ user: null, loading: false, error: error.message, isAuthenticated: false }) ;

      },
    })
  }

  constructor() { }
}
