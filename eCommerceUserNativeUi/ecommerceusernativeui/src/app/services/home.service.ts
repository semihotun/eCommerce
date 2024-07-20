import { Injectable, inject } from '@angular/core';
import { HttpService } from './http.service';
import { Destroyable } from '../shared/destroyable.service';
import { environment } from 'src/environments/environment';
import { Slider } from '../models/responseModel/Slider';
import { HomeStore } from '../stores/home.store';
import { Showcase } from '../models/responseModel/Showcase';
import { HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class HomeService extends Destroyable {
  http = inject(HttpService);
  homeStore = inject(HomeStore);

  constructor() {
    super();
  }

  getAllSlider() {
    const url = environment.baseUrl + 'sliderqueryservice/getallslider';
    this.http.get<Slider[]>(url, {}, this.onDestroy, (data) => {
      this.homeStore.setSliders(data);
    });
  }

  getShowCaseList() {
    const url =
      environment.baseUrl + 'showcasedtoqueryservice/getallshowcasedto';
    this.http.get<Showcase[]>(url, {}, this.onDestroy, (data) => {
      this.homeStore.setShowcases(data);
    });
  }
}
