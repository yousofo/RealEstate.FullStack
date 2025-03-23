import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-side-nav',
  standalone: true,
  templateUrl: './side-nav.component.html',
  styleUrl: './side-nav.component.css',
  imports: [RouterLink,RouterLinkActive],
})
export class SideNavComponent {

}
