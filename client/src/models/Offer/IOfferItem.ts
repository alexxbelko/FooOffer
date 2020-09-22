import {IAlternative} from "../Alternatives/IAlternative";

export interface IOfferItem {
  alternative: IAlternative,
  amount: number,
  sum: number
}
