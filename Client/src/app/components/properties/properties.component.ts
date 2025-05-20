import { ChangeDetectionStrategy, Component, effect, inject, input, OnInit, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { IFetchCount } from '../../types/fetch';
import { IProperty } from '../../types/properties';
import { PropertyCardComponent } from '../property-card/property-card.component';
import { PropertiesService } from '../../services/properties/properties.service';
import { Skeleton } from 'primeng/skeleton';

@Component({
  selector: 'app-properties',
   templateUrl: './properties.component.html',
  styleUrl: './properties.component.scss',
  imports: [PropertyCardComponent,Skeleton],
})
export class PropertiesComponent implements OnInit {
  properties = signal<IProperty[]>([]);
  placeholderArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];

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
    this.propertiesService.getPage().subscribe({
      next: (properties) => {
        this.properties.set(properties.items);
      },
    })
  }
}
