import { Component } from '@angular/core';
import {
  IonHeader,
  IonToolbar,
  IonTitle,
  IonContent,
  IonRouterOutlet,
} from '@ionic/angular/standalone';
import { GlobalService } from 'src/app/services/global.service';
import { FooterComponent } from 'src/app/uı/footer/footer.component';
import { HeaderComponent } from 'src/app/uı/header/header.component';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
  standalone: true,
  imports: [
    IonRouterOutlet,
    IonHeader,
    IonToolbar,
    IonTitle,
    IonContent,
    HeaderComponent,
    FooterComponent,
  ],
})
export class HomePage {
  constructor(public glb: GlobalService) {}
}
