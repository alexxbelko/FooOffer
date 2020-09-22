import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private apiBaseUrl = "https://localhost:8000/api/v1";

  constructor(private httpClient: HttpClient) { }

  public getAllCities(){
    return this.httpClient.get(`${this.apiBaseUrl}/cities`);
  }

  public getAvalilableAlternativesByCityId(selectedCityId) {
    return this.httpClient.get(`${this.apiBaseUrl}/cities/${selectedCityId}`);
  }

  public calculateOffer(newOfferRequest) {
    return this.httpClient.post(`${this.apiBaseUrl}/offer`, newOfferRequest);
  }
}

//The functionality of this service would be splitted into different services, in a bigger application.
