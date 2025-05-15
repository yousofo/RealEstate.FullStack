import { Directive, EventEmitter, HostListener, Input, Output } from '@angular/core';
import { debounceTime, Subject } from 'rxjs';

@Directive({
  selector: '[appDebounceClick]'

})
export class DebounceClickDirective {

  @Input() debounceClick = 400;
  @Output() debouncedClick = new EventEmitter();

  private clicks = new Subject<void>();

  constructor() {
    this.clicks
      .pipe(debounceTime(this.debounceClick))
      .subscribe(() => this.debouncedClick.emit());
  }

  @HostListener('click')
  clickEvent() {
    this.clicks.next();
  }

}
