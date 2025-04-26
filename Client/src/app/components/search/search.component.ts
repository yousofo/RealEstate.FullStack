import { Component } from '@angular/core';

@Component({
  selector: 'app-search',
  standalone: true,
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss',
  host:{
    class: 'w-full'
  }
})
export class SearchComponent {
  onInput() {
    console.log("changed")
  }
}
