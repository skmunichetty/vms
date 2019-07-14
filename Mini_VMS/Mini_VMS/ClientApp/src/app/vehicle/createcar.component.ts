import { Component, Input } from '@angular/core';
import { Http, Response } from '@angular/http'
import { Service } from '../services/service'
import { IVehicle } from "./vehicle";

@Component({
  selector: 'createcar',
  templateUrl: './createcar.component.html'
})

export class CreateCarComponent {

  @Input() childMessage: any;

  public createCarApiUrl: string;
  public bodyTypes: string;
  public allCars: string;
  public errorMessage: any;

  public carMake: any;
  public carModel: any;
  public carEngine: any;
  public carDoors: any;
  public carWheels: any;
  public carBodyType: any;



  constructor(private _http: Http, private _service: Service) {
    //this.createCarApiUrl = configuration.createCarApiUrl;
  }

  ngOnInit(): void {

    this._service.getBodyTypes().subscribe(
      data => {
        this.bodyTypes = data.returnValue;
      },
      error => this.errorMessage = <any>error
    );

    this._service.getAllCars().subscribe(
      data => {
        this.allCars = data.returnValue;
      },
      error => this.errorMessage = <any>error
    );

  }

  onSelectedBodyType(val): void {
    console.log(val);
    this.carBodyType = val;
  }

  addCar(): void {
    console.log(this.carBodyType);
    const newCar: IVehicle = {
      make: this.carMake,
      model: this.carModel,
      engine: this.carEngine,
      doors: this.carDoors,
      wheels: this.carWheels,
      bodyTypeId: this.carBodyType,
      vehicleTypeId: 1 // Car
    } as IVehicle;
    this._service.addCar(newCar).subscribe();
    alert("Details Saved");

  }
}
