import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button'
@Component({
  selector: 'app-home-page',
  standalone: true,
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css',
  imports: [ButtonModule]
})
export class HomePageComponent {

}
