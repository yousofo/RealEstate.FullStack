import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button'
import { PropertiesComponent } from '../../components/properties/properties.component';
import { PropertySearchComponent } from "../../components/property-search/property-search.component";
@Component({
  selector: 'app-home-page',
  standalone: true,
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss',
  imports: [ButtonModule, PropertiesComponent, PropertySearchComponent]
})
export class HomePageComponent {

}
