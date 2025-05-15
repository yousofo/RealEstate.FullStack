import { Component } from '@angular/core';
import { DebounceClickDirective } from '../../../directives/debounce-click.directive';

@Component({
  selector: 'app-choose-property-location',
  imports: [DebounceClickDirective],
  templateUrl: './choose-property-location.component.html',
  styleUrl: './choose-property-location.component.scss'
})
export class ChoosePropertyLocationComponent {

  


  onClick(query: string) {
    //use debounce
    console.log(query);
  }


}
