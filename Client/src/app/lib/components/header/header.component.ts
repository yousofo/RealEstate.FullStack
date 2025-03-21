import { Component, inject, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { LoginService } from '../../services/popups/login/login.service';
import { ButtonModule } from 'primeng/button';
import { AuthService } from '../../services/auth/auth.service';

@Component({
  selector: 'app-header',
  standalone: true,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  imports: [RouterLink,RouterLinkActive, ButtonModule],
})
export class HeaderComponent implements OnInit {
  isDiscount: boolean = false;
  loginService = inject(LoginService);
  authService= inject(AuthService);

  ngOnInit() {
    console.log("from header")
  }
}
