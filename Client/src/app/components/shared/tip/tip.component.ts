import { ChangeDetectionStrategy, ChangeDetectorRef, Component, inject, input, signal } from '@angular/core';
import { interval, Subject } from 'rxjs';

@Component({
  selector: 'app-tip',
  imports: [],
  templateUrl: './tip.component.html',
  styleUrl: './tip.component.scss',
 })
export class TipComponent {
  message = input(
    'This is a tip component that can be used to display helpful tips or information to users.'
  );
  direction = input<'top' | 'bottom' | 'left' | 'right'>('bottom');
  visible = signal(true);
  subject = interval()
  changeDetectionRed = inject(ChangeDetectorRef)
  hideTip() {
    // this.changeDetectionRed
    this.visible.set(false);
  }
}
