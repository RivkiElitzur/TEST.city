import { Component, OnInit, Input } from '@angular/core';
import { City } from 'src/app/models/city.model';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
})
export class TableComponent implements OnInit {
  @Input() data: City[] = [];
  datae: City[] = [];
  constructor() {}

  ngOnInit(): void {}
}
