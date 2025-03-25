//import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { HeaderComponent } from './lib/components/header/header.component';
import { FooterComponent } from './lib/components/footer/footer.component';
import { SearchComponent } from './lib/components/search/search.component';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { SideNavComponent } from './lib/components/side-nav/side-nav.component';
import { LoginComponent } from './lib/components/login/login.component';
import { ChatAIComponent } from './lib/components/chat-ai/chat-ai.component';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  // standalone: true,
  imports: [
    HeaderComponent,
    FooterComponent,
    SearchComponent,
    RouterOutlet,
    SideNavComponent,
    LoginComponent,
    ChatAIComponent,
    SideNavComponent,ToastModule
],
  providers: [HttpClient,MessageService],
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  private http = inject(HttpClient);

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  //title = 'realestatefullstackapp.client';
}
