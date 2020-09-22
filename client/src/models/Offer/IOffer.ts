import {IOfferItem} from "./IOfferItem";

export interface IOffer {
  offerDateTime: Date,
  city: string,
  offerItems: Array<IOfferItem>,
  grandTotal: number,
  currency: string
}
