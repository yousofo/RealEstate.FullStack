//import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { SearchComponent } from './components/search/search.component';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { SideNavComponent } from './components/side-nav/side-nav.component';
import { LoginComponent } from './components/login/login.component';
import { ChatAIComponent } from './components/chat-ai/chat-ai.component';
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
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  // public forecasts: WeatherForecast[] = [];

  private http = inject(HttpClient);

  ngOnInit() {
    // this.getForecasts();
  }


  //title = 'realestatefullstackapp.client';
}
