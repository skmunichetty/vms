import { Component, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import { configuration } from '../models/Configuration';

import { map } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [configuration]
})
export class HomeComponent {

  public vehicleTypes$: any;

  public getVehiclesApiUrl: string;
  public getBodyTypesApiUrl: string;
  public createCarApiUrl: string;
  public errorMessage: string;

  constructor(private _http: Http, private configuration: configuration) {
    //getCheapestTicket():
    this.getVehiclesApiUrl = configuration.getVehiclesApiUrl;
    this.getBodyTypesApiUrl = configuration.getBodyTypesApiUrl;
    this.createCarApiUrl = configuration.createCarApiUrl;
  }

  ngOnInit(): void {
    this._http.get(this.getVehiclesApiUrl).pipe(map((resp: any) => resp.json()))
      .subscribe((apiresult: any) => {
        if (apiresult.isValid) {
          this.vehicleTypes$ = apiresult.returnValue;
        }
        console.log(this.vehicleTypes$);

      });
  }
}
