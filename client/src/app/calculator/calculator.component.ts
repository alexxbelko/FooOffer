import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { element } from "protractor";
import {ListboxModule} from 'primeng/listbox';
import {InputNumberModule} from 'primeng/inputnumber';
import {DropdownModule} from 'primeng/dropdown';

import { IOffer } from "../../models/Offer/IOffer";
import { INewOffer } from "../../models/Offer/INewOffer";
import { IOfferAlternative } from "../../models/Offer/IOfferAlternative";
import { OfferComponent } from "../offer/offer.component";

@Component({
  selector: 'app-alternatives',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {
  form: FormGroup;
  selectedCity;
  cities = [];
  availableAlternatives: any;
  mainAlternativeAmount: 1;
  offer: IOffer;
  mainAmountValidationClass: string;

  constructor(private dataService: DataService, private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      name: ['', {validators: [Validators.required]}],
      alt: this.formBuilder.array([])
    });
  }

  ngOnInit(): void {
    this.getAllCities();
  }

  public getAllCities() {
    this.dataService.getAllCities().subscribe((data: any[]) =>{
      this.cities = data;
    });
  }

  public getAvalilableAlternatives() {
    this.offer = null;
    this.availableAlternatives = [];

    if(this.selectedCity){
      this.dataService.getAvalilableAlternativesByCityId(this.selectedCity.id).subscribe((data: any[]) => {
        const control = this.alternativeFormArray;
        control.controls = [];
        data.forEach(x => {
          control.controls.push(
            this.formBuilder.group({
              key: x.key,
              value: x.value,
              name: `${x.name} (${x.unitPrice} kr/${x.unit})`,
              isDisabled: x.value
            })
          )
        });

        this.availableAlternatives = this.form.controls.alt['controls'];
      })
    }
  }

  get alternativeFormArray() {
    return <FormArray>this.form.controls.alt;
  }

  public calculateOffer() {
    if(this.selectedCity && this.mainAlternativeAmount > 0){
      const newOfferRequest: INewOffer = {
        cityId: this.selectedCity.id,
        alternatives: this.getSelectedAlternatives(),
        mainAlternativeAmount: Number(this.mainAlternativeAmount)
      }

      this.dataService.calculateOffer(newOfferRequest).subscribe((data: IOffer) => {
        this.offer = data;
      });
    }
  }

  private getSelectedAlternatives() {
    return this.availableAlternatives.filter(x => x.value.value).map(x => x.value.key);
  }

  public setMainAmountValidationClass() {
    if(this.mainAlternativeAmount > 0) {
      return "";
    }
    else {
      return "p-error";
    }
  }
}
