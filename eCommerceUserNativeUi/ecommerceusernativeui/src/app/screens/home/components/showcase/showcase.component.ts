import { Component, inject, OnInit } from '@angular/core';
import { ShowcaseSwiperComponent } from './components/showcase-swiper/showcase-swiper.component';
import { ShowcaselistComponent } from './components/showcaselist/showcaselist.component';
import { HomeStore } from 'src/app/stores/home.store';
import { HomeService } from 'src/app/services/home.service';
import { ShowcaseTextComponent } from './components/showcase-text/showcase-text.component';
import { ShowcaseType } from 'src/app/models/enums/ShowcaseType';

@Component({
  selector: 'app-showcase',
  templateUrl: './showcase.component.html',
  styleUrls: ['./showcase.component.scss'],
  standalone: true,
  imports: [
    ShowcaseSwiperComponent,
    ShowcaselistComponent,
    ShowcaseTextComponent,
  ],
})
export class ShowcaseComponent implements OnInit {
  homeService = inject(HomeService);
  homeStore = inject(HomeStore);
  showcaseType = ShowcaseType;
  constructor() {}

  ngOnInit() {
    this.homeService.getShowCaseList();
  }
}
