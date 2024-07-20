import { CommonModule } from '@angular/common';
import {
  AfterViewInit,
  CUSTOM_ELEMENTS_SCHEMA,
  Component,
  ElementRef,
  OnInit,
  ViewChild,
  inject,
} from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { HomeService } from 'src/app/services/home.service';
import { HomeStore } from 'src/app/stores/home.store';
import { Swiper } from 'swiper/types';
import { LazyImgDirective } from './../../../../directives/lazy-img.directive';
@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  standalone: true,
  styleUrls: ['./slider.component.scss'],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  imports: [CommonModule, TranslateModule, LazyImgDirective],
})
export class SliderComponent implements AfterViewInit, OnInit {
  @ViewChild('swiper') swiperRef: ElementRef | undefined;
  swiper?: Swiper;
  homeService = inject(HomeService);
  homeStore = inject(HomeStore);
  ngOnInit(): void {
    this.homeService.getAllSlider();
  }
  goNext() {
    this.swiper?.slideNext();
  }
  goPrev() {
    this.swiper?.slidePrev();
  }
  ngAfterViewInit(): void {}
  swiperInit() {
    this.swiper = this.swiperRef?.nativeElement.swiper;
    this.swiper?.autoplay.start();
  }
}
