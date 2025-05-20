import { Component, inject, signal, effect } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { Dialog } from 'primeng/dialog';
import { AuthService } from '../../../services/auth/auth.service';
import { MessageService } from 'primeng/api';
import { Toast, ToastModule } from 'primeng/toast';
import { IResult } from '../../../types/fetch';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  imports: [
    FormsModule,
    InputTextModule,
    Dialog,
    ButtonModule,
    InputTextModule,
  ],
  // providers: [MessageService],
})
export class LoginComponent {
  emailInput = '';
  passwordInput = '';

  authService = inject(AuthService);
  messageService = inject(MessageService);

  submit(form: NgForm) {
    console.log(form);
    // this.authService.login(form.controls['email'].value, form.controls['password'].value);
    this.authService.login(this.emailInput, this.passwordInput).subscribe({
      next: (user) => {
        console.log(user);
        if (!user?.token) {
          throw new Error('Access Denied');
        }
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: (err.error as IResult).error.message,
          life: 3000,
        });
      },

      complete: () => {
        // this.loadingService.stop();
      },
    });
  }

  closeDialog() {
    this.messageService.add({
      severity: 'info',
      summary: 'Info',
      detail: 'Dialog closed',
      life: 3000,
    });
    this.authService.closeDialog();
  }
}
/**
 * <form action="">
    <!-- email -->
    <section class="flex flex-col gap-2">
        <label for="email">Email Address</label>
        <input pInputText id="email" aria-describedby="email-help" [(ngModel)]="emailInput" />
        <small id="email-help">Enter your email address to reset your password.</small>
    </section>

    
     <!-- password -->
     <section class="flex flex-col gap-2">
        <label for="password">password Address</label>
        <input pInputText id="password" aria-describedby="password-help" [(ngModel)]="passwordInput" />
        <small id="password-help">Enter your password address to reset your password.</small>
    </section>
</form>
 */
