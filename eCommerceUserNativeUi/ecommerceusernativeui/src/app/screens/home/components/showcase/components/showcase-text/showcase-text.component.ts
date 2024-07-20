import { Component, Input, OnInit } from '@angular/core';
import { Showcase } from 'src/app/models/responseModel/Showcase';

@Component({
  selector: 'app-showcase-text',
  templateUrl: './showcase-text.component.html',
  standalone: true,
  styleUrls: ['./showcase-text.component.scss'],
})
export class ShowcaseTextComponent implements OnInit {
  @Input() data!: Showcase;
  constructor() {}

  ngOnInit() {}
}
