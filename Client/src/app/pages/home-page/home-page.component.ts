import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button'
import { PropertiesComponent } from '../../lib/components/properties/properties.component';
@Component({
  selector: 'app-home-page',
  standalone: true,
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css',
  imports: [ButtonModule,PropertiesComponent]
})
export class HomePageComponent {

}
