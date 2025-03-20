import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  imports: [RouterLink,RouterLinkActive],
})
export class HeaderComponent implements OnInit {
  isDiscount: boolean = false;

  ngOnInit() {
    console.log("from header")
  }
}
