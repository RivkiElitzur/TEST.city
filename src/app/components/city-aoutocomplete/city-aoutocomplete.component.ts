import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CityService } from 'src/app/services/city.service';
import { FormControl } from '@angular/forms';
import { City } from 'src/app/models/city.model';

@Component({
  selector: 'app-city-aoutocomplete',
  templateUrl: './city-aoutocomplete.component.html',
  styleUrls: ['./city-aoutocomplete.component.scss'],
})
export class CityAoutocompleteComponent implements OnInit {
  @Output() redirect: EventEmitter<City[]> = new EventEmitter();
  myControl = new FormControl('');
  options: string[] = [];
  filteredOptions: string[] | undefined;
  constructor(private cityService: CityService) {}

  ngOnInit() {
    this.myControl.valueChanges.subscribe((value) => this._filter(value || ''));
  }

  private _filter(value: string) {
    if (value == '') return;
    const filterValue = value.toLowerCase();
    this.cityService.getCityList(filterValue).subscribe((res) => {
      this.filteredOptions = res;
    });
  }

  optionSelected(value: string) {
    this.cityService.getDataByCity(value).subscribe((res: City[]) => {
      this.redirect.next(res);
    });
  }
}
