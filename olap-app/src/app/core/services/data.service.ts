import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../../environments/environment";
import {IndicatorInterface} from "../interfaces/indicator.interface";
import {CountryInterface} from "../interfaces/country.interface";
import {DataInterface} from "../interfaces/data.interface";

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) {}

  public getData(): Observable<DataInterface[]> {
    return this.http.get<DataInterface[]>(environment.baseApi + 'dataPoint/all');
  }

  public updateData(data: any, id: string): Observable<any> {
    return this.http.put(environment.baseApi + 'dataPoint', {...data}, {params: {id}});
  }

  public getCountries(): Observable<CountryInterface[]> {
    return this.http.get<CountryInterface[]>(environment.baseApi + 'country/all');
  }

  public getIndicators(): Observable<IndicatorInterface[]> {
    return this.http.get<IndicatorInterface[]>(environment.baseApi + 'indicator/all');
  }
}
