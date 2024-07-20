import { Injectable } from '@angular/core';
import { Slider } from '../models/responseModel/Slider';
import { ComponentStore } from '@ngrx/component-store';
import { Showcase } from '../models/responseModel/Showcase';

export type HomeState = {
  sliders: Slider[];
  showcases: Showcase[];
};

export const homeInitialState: HomeState = {
  sliders: [],
  showcases: [],
};

@Injectable({
  providedIn: 'root',
})
export class HomeStore extends ComponentStore<HomeState> {
  readonly sliders$ = this.selectSignal((x) => x.sliders);
  readonly showcases$ = this.selectSignal((x) => x.showcases);

  constructor() {
    super(homeInitialState);
  }

  readonly setSliders = this.updater((state, sliders: Slider[]) => ({
    ...state,
    sliders,
  }));

  readonly setShowcases = this.updater((state, showcases: Showcase[]) => ({
    ...state,
    showcases,
  }));
}
