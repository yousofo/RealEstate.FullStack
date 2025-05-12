import { Component, inject } from '@angular/core';
import { FormsModule, NgForm, NgModel } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { PhonePipe } from '../../pipes/phone.pipe';
import { AuthService } from '../../services/auth/auth.service';

@Component({
  selector: 'app-sign-up-page',
  imports: [InputTextModule, FormsModule, PasswordModule,PhonePipe],
  templateUrl: './sign-up-page.component.html',
  styleUrl: './sign-up-page.component.scss',
})
export class SignUpPageComponent {

  authService = inject(AuthService);

  onSubmit(form: NgForm) {

    if (!form.valid) {
      console.log('invalid form');
      console.log(form.errors)
      return;
    };
    console.log(form.value);
    this.authService.signup(form.value).subscribe({
      next: (user) => {
        console.log(user);
      },
      error: (error) => {
        console.error(error);
      },
    });

  }
  handleError(element:HTMLInputElement, elementError:HTMLElement){
    elementError.classList.remove('hidden')
  }
}
