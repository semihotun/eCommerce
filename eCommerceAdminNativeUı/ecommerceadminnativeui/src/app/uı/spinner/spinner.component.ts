import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { IonSpinner } from '@ionic/angular/standalone';
import { LoaderService } from 'src/app/services/loader.service';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.scss'],
  encapsulation: ViewEncapsulation.ShadowDom,
  standalone: true,
  imports: [IonSpinner, CommonModule],
})
export class SpinnerComponent implements OnInit {
  constructor(public loader: LoaderService) {}

  ngOnInit() {}
}
