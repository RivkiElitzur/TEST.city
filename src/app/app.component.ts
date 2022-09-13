import { Component } from '@angular/core';
import { City } from './models/city.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  parentData: City[] = [];
  title = 'frontend';
}
