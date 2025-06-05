//import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { Header } from './components/shared/header/header';
import { FooterComponent } from './components/shared/footer/footer.component';
import { SearchComponent } from './components/search/search.component';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { SideNavComponent } from './components/shared/side-nav/side-nav.component';
import { LoginComponent } from './components/shared/login/login.component';
import { ChatAIComponent } from './components/chat-ai/chat-ai.component';
import { Toast, ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  imports: [
    Header,
    FooterComponent,
    SearchComponent,
    RouterOutlet,
    SideNavComponent,
    LoginComponent,
    ChatAIComponent,
    Toast,
  ],
  providers: [MessageService],
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  ngOnInit() {
    // this.getForecasts();
  }

  //title = 'realestatefullstackapp.client';
}
