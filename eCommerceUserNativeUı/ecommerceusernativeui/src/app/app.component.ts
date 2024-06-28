import { Component } from '@angular/core';
import {
  IonApp,
  IonRouterOutlet,
  IonContent,
  IonHeader,
} from '@ionic/angular/standalone';
import { HeaderComponent } from './uı/header/header.component';
import { RouterModule } from '@angular/router';
import { register } from 'swiper/element/bundle';
register();
@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  standalone: true,
  imports: [
    IonHeader,
    IonContent,
    IonApp,
    IonRouterOutlet,
    HeaderComponent,
    RouterModule,
  ],
})
export class AppComponent {
  constructor() {}
}
