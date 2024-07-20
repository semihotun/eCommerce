import { Component, Input, OnInit } from '@angular/core';
import { Showcase } from 'src/app/models/responseModel/Showcase';

@Component({
  selector: 'app-showcaselist',
  templateUrl: './showcaselist.component.html',
  styleUrls: ['./showcaselist.component.scss'],
  standalone: true,
})
export class ShowcaselistComponent implements OnInit {
  @Input() data!: Showcase;
  constructor() {}
  ngOnInit() {}
}
