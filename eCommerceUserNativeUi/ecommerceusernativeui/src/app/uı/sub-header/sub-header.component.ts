import { Component, inject, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {
  IonContent,
  IonHeader,
  IonTitle,
  IonToolbar,
} from '@ionic/angular/standalone';
import { TranslateModule } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { GlobalService } from 'src/app/services/global.service';

@Component({
  selector: 'app-sub-header',
  templateUrl: './sub-header.component.html',
  styleUrls: ['./sub-header.component.scss'],
  standalone: true,
  imports: [
    IonContent,
    IonHeader,
    IonTitle,
    IonToolbar,
    CommonModule,
    FormsModule,
  ],
})
export class SubHeaderComponent implements OnInit {
  @Input() previousUrl: any[] = [];
  @Input() title: string = '';
  router = inject(Router);
  glb = inject(GlobalService);
  isPreviousUrl: boolean = false;
  constructor() {}

  routerNavigate() {
    if (this.isPreviousUrl) {
      this.router.navigate(this.previousUrl);
    }
  }
  ngOnInit() {
    if (this.previousUrl.length > 0) {
      this.isPreviousUrl = true;
    }
  }
}
