import { Component, inject, input, OnInit, signal } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { IFetchCount } from '../../types/fetch';
import { IProperty } from '../../types/properties';
import { PropertyCardComponent } from '../property-card/property-card.component';

@Component({
  selector: 'app-properties',
  standalone: true,
  templateUrl: './properties.component.html',
  styleUrl: './properties.component.css',
  imports: [PropertyCardComponent],
})
export class PropertiesComponent implements OnInit {
  fetchConfig = input<IFetchCount>({
    pageCount: 9,
  });

  properties = signal<IProperty[]>([]);

  httpClient = inject(HttpClient);

  ngOnInit(): void {
    this.httpClient
      .get<IProperty[]>(`${environment.apiUrl}/api/properties`)
      .subscribe({
        next: (properties) => {
          console.log(properties);
          this.properties.set(properties);
        },
        error: (error) => {
          console.error(error);
        },
      });
  }
}
