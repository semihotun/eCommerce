import { Component, OnInit } from '@angular/core';
import { ShowcaseSwiperComponent } from './components/showcase-swiper/showcase-swiper.component';
import { ShowcaselistComponent } from './components/showcaselist/showcaselist.component';

@Component({
  selector: 'app-showcase',
  templateUrl: './showcase.component.html',
  styleUrls: ['./showcase.component.scss'],
  standalone: true,
  imports: [ShowcaseSwiperComponent, ShowcaselistComponent],
})
export class ShowcaseComponent implements OnInit {
  constructor() {}

  ngOnInit() {}
}
