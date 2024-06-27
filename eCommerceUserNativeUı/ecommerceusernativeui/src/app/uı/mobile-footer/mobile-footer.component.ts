import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { GlobalService } from 'src/app/services/global.service';
import { IonIcon } from '@ionic/angular/standalone';

@Component({
  selector: 'app-mobile-footer',
  templateUrl: './mobile-footer.component.html',
  styleUrls: ['./mobile-footer.component.scss'],
  standalone: true,
  imports: [IonIcon, CommonModule],
})
export class MobileFooterComponent implements OnInit {
  constructor(public glb: GlobalService) {}

  ngOnInit() {}
}
