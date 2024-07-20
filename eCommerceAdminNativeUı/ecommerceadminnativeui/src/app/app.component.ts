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
import {
  TranslateModule,
  TranslatePipe,
  TranslateService,
} from '@ngx-translate/core';
import { SpinnerComponent } from './u\u0131/spinner/spinner.component';
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
    TranslateModule,
    SpinnerComponent,
  ],
})
export class AppComponent {
  constructor(private translate: TranslateService) {
    this.translate.setDefaultLang('tr');
  }
}
