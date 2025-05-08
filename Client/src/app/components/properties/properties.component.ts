import { ChangeDetectionStrategy, Component, effect, inject, input, OnInit, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { IFetchCount } from '../../types/fetch';
import { IProperty } from '../../types/properties';
import { PropertyCardComponent } from '../property-card/property-card.component';
import { PropertiesService } from '../../services/properties/properties.service';

@Component({
  selector: 'app-properties',
  standalone: true,
  templateUrl: './properties.component.html',
  styleUrl: './properties.component.scss',
  imports: [PropertyCardComponent],
})
export class PropertiesComponent implements OnInit {
  properties = signal<IProperty[]>([]);


  fetchConfig = input<IFetchCount>({
    pageCount: 9,
  });


  propertiesService = inject(PropertiesService);

/**
 *
 */
constructor() {
  //  effect(e=>{
  //   this.properties.set(this.propertiesService.properties());
  // })
}
  
  ngOnInit(): void {
    
  }
}
