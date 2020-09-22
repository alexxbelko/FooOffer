import {Component, Input, OnInit} from '@angular/core';
import {IOffer} from "../../models/Offer/IOffer";

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css']
})
export class OfferComponent implements OnInit {
  @Input() offer: IOffer;

  constructor() {
      console.log(this.offer);
  }

  ngOnInit(): void {
  }

}
