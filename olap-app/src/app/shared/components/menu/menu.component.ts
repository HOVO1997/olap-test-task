import {booleanAttribute, Component, EventEmitter, Input, Output} from '@angular/core';
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatMenuModule} from "@angular/material/menu";
import {MatOptionModule} from "@angular/material/core";
import {MatSelectChange, MatSelectModule} from "@angular/material/select";
import {DataInterface} from "../../../core/interfaces/data.interface";
import {CountryInterface} from "../../../core/interfaces/country.interface";
import {IndicatorInterface} from "../../../core/interfaces/indicator.interface";

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatMenuModule,
    MatOptionModule,
    MatSelectModule
  ],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss',
})
export class MenuComponent {
  @Input({transform: booleanAttribute}) isInCountry: boolean = false;
  @Input({required: true}) element!: DataInterface;
  @Input() countries: CountryInterface[] = [];
  @Input() indicators: IndicatorInterface[] = [];
  @Output() emitElementSelect: EventEmitter<{ event: MatSelectChange, element: DataInterface }> =
    new EventEmitter<{ event: MatSelectChange, element: DataInterface }>();

  public onElementSelect(event: MatSelectChange, element: DataInterface): void {
    this.emitElementSelect.emit({event, element});
  }
}
