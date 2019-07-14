import { Injectable } from '@angular/core';

@Injectable()
export class Configuration {
  public apiUrl = document.location.protocol + '/api/';
  public controller = 'CarSales/';
  public getVehiclesApiUrl = this.apiUrl + this.controller + "GetVehicles";
  public getBodyTypesApiUrl = this.apiUrl + this.controller + "GetBodyTypes";
  public createCarApiUrl = this.apiUrl + this.controller + "CreateCar";
}
