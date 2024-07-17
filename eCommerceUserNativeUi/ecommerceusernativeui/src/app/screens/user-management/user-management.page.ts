import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {
  IonContent,
  IonHeader,
  IonTitle,
  IonToolbar,
  IonBackButton,
} from '@ionic/angular/standalone';
import { HeaderComponent } from 'src/app/uı/header/header.component';
import { GlobalService } from 'src/app/services/global.service';
import { FooterComponent } from 'src/app/uı/footer/footer.component';
import { MobileFooterComponent } from 'src/app/uı/mobile-footer/mobile-footer.component';
import { TranslateModule } from '@ngx-translate/core';
import { RouterModule } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { SubHeaderComponent } from 'src/app/uı/sub-header/sub-header.component';
@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.page.html',
  styleUrls: ['./user-management.page.scss'],
  standalone: true,
  imports: [
    IonBackButton,
    IonContent,
    IonHeader,
    IonTitle,
    IonToolbar,
    CommonModule,
    FormsModule,
    HeaderComponent,
    FooterComponent,
    MobileFooterComponent,
    TranslateModule,
    RouterModule,
    SubHeaderComponent,
  ],
})
export class UserManagementPage implements OnInit {
  glb = inject(GlobalService);
  userService = inject(UserService);
  constructor() {}

  ngOnInit() {}
  logout() {
    this.userService.logOut();
  }
}
