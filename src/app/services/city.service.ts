import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { City } from '../models/city.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private http: HttpClient) { }
  url: string =  `${environment.api}/City`;


  getCityList(name: string): Observable<string[]> {
    const url = `${this.url}/${name}`;
    return this.http.get<string[]>(url);
  }

  getDataByCity(name: string): Observable<City[]> {
    const url = `${this.url}/get-data/${name}`;
    return this.http.get<City[]>(url);
  }
}
