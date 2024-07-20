import { CommonModule } from '@angular/common';
import {
  AfterViewInit,
  CUSTOM_ELEMENTS_SCHEMA,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
  input,
} from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { LazyImgDirective } from 'src/app/directives/lazy-img.directive';
import { Showcase } from 'src/app/models/responseModel/Showcase';
import { GlobalService } from 'src/app/services/global.service';
import { Swiper } from 'swiper/types';
@Component({
  selector: 'app-showcase-swiper',
  templateUrl: './showcase-swiper.component.html',
  styleUrls: ['./showcase-swiper.component.scss'],
  standalone: true,
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  imports: [CommonModule, LazyImgDirective, TranslateModule],
})
export class ShowcaseSwiperComponent implements AfterViewInit {
  @ViewChild('swiper') swiperRef: ElementRef | undefined;
  swiper?: Swiper;
  @Input() data!: Showcase;
  constructor(public glb: GlobalService) {}
  goNext() {
    this.swiper?.slideNext();
  }
  goPrev() {
    this.swiper?.slidePrev();
  }
  ngAfterViewInit(): void {
    this.swiper = this.swiperRef?.nativeElement.swiper;
  }
}
