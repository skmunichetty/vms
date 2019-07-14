import { Component } from '@angular/core';
import { Http, Response } from '@angular/http'
import { Configuration } from '../Configuration'
//import "rxjs/add/operator/map"
import { Observable } from 'rxjs'
import { Service } from '../services/service'

import { map } from 'rxjs/operators'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [Configuration]
})
export class HomeComponent {

  public getVehiclesApiUrl: string;

  constructor(private configuration: Configuration, private _http: Http, private _service: Service) {
    this.getVehiclesApiUrl = configuration.getVehiclesApiUrl;
  }

  public selectedVehicleType: any = "Select a Vehicle Type";
  public test: any;
  public errorMessage: any;
  // Vehicle Types should be an API

  public vehicleTypes: any[];
  
  onSelectedOption(val) {
    console.log(val);
    this.selectedVehicleType = val;
  }

  ngOnInit(): void {
    this._service.getVehicles().subscribe(
      vehicles => {
        this.vehicleTypes = vehicles.returnValue;
      },
      error => this.errorMessage = <any>error
    );

    //this.test = this.getVehicleTypes();
    //console.log(this.test);
  }

  getVehicleTypes(): Observable<any> {
    return this._http.get(this.getVehiclesApiUrl);
  }
}


