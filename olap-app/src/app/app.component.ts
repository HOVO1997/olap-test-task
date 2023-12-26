import {ChangeDetectionStrategy, Component, OnInit} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterOutlet} from '@angular/router';
import {MatTableModule} from "@angular/material/table";
import {DataService} from "./core/services/data.service";
import {Observable} from "rxjs";
import {MatMenuModule} from "@angular/material/menu";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatButtonModule} from "@angular/material/button";
import {MatSelectChange, MatSelectModule} from "@angular/material/select";
import {ReactiveFormsModule} from "@angular/forms";
import {CountryInterface} from "./core/interfaces/country.interface";
import {IndicatorInterface} from "./core/interfaces/indicator.interface";
import {DataInterface} from "./core/interfaces/data.interface";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    MatTableModule,
    MatMenuModule,
    MatFormFieldModule,
    MatSelectModule,
    MatButtonModule,
    ReactiveFormsModule
  ],
  providers: [
    DataService
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  public displayedColumns: string[] =
    ['country_name', 'country_code', 'indicator_name',
      'indicator_code', 'frequency', 'date', 'value'];
  public dataList$!: Observable<DataInterface[]>;
  public countries: CountryInterface[] = [];
  public indicators: IndicatorInterface[] = [];

  constructor(
    private dataService: DataService,
  ) {}

  ngOnInit(): void {
    this.getData();
    this.getCountries();
    this.getIndicators();
  }

  private getData(): void {
    this.dataList$ = this.dataService.getData();
  }

  private getCountries(): void {
    this.dataService.getCountries().subscribe((response: CountryInterface[]): void => {
      this.countries = response;
    });
  }

  private getIndicators(): void {
    this.dataService.getIndicators().subscribe((response: IndicatorInterface[]): void => {
      this.indicators = response;
    });
  }

  public onCountrySelect(event: MatSelectChange, element: DataInterface): void {
    const payload = {
      ...element,
      countryId: event.value
    }
    this.updateData(payload, element.id);
  }

  public onIndicatorSelect(event: MatSelectChange, element: DataInterface): void {
    const payload = {
      ...element,
      indicatorId: event.value
    }
    this.updateData(payload, element.id);
  }

  private updateData(payload: DataInterface, id: string): void {
    this.dataService.updateData(payload, id)
      .subscribe(_ => this.getData());
  }
}
