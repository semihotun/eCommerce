import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import {
  IonIcon,
  IonHeader,
  IonMenu,
  IonToolbar,
  IonButtons,
  IonTitle,
  IonContent,
  IonMenuButton,
  NavController,
} from '@ionic/angular/standalone';
import { Router, RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  standalone: true,
  imports: [
    IonContent,
    IonTitle,
    IonButtons,
    IonIcon,
    CommonModule,
    RouterModule,
    TranslateModule,
    IonMenu,
    IonHeader,
    IonToolbar,
    IonMenuButton,
    RouterModule,
  ],
})
export class HeaderComponent implements OnInit {
  navCtrl = inject(NavController);
  router = inject(Router);
  initRoute: string = '';
  @Input() title: string = '';
  @Input() backButton: boolean = false;

  ngOnInit(): void {}
  routerNavigate() {
    this.navCtrl.back();
  }
}
