import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {
  IonContent,
  IonHeader,
  IonTitle,
  IonToolbar,
} from '@ionic/angular/standalone';
import { HeaderComponent } from '../../u\u0131/header/header.component';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.page.html',
  styleUrls: ['./brand.page.scss'],
  standalone: true,
  imports: [
    IonContent,
    IonHeader,
    IonTitle,
    IonToolbar,
    CommonModule,
    FormsModule,
    HeaderComponent,
  ],
})
export class BrandPage implements OnInit {
  constructor() {}

  ngOnInit() {}
}
