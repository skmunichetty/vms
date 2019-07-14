import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IVehicle } from "../vehicle/vehicle";


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class Service {
  private getVechiclesUrl = 'http://localhost:53934/api/CarSales/GetVehicles';
  private getBodyTypesUrl = 'http://localhost:53934/api/CarSales/GetBodyTypes';
  private createCarUrl = 'http://localhost:53934/api/CarSales/CreateCar';
  private getAllCarsUrl = 'http://localhost:53934/api/CarSales/GetAllCars';

  constructor(private http: HttpClient) { }
  

  getVehicles(): Observable<any> {
    return this.http.get<any>(this.getVechiclesUrl).pipe(
      tap(data => console.log("All: " + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }


  getBodyTypes(): Observable<any> {
    return this.http.get<any>(this.getBodyTypesUrl).pipe(
      tap(data => console.log("All: " + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  getAllCars(): Observable<any> {
    return this.http.get<any>(this.getAllCarsUrl).pipe(
      tap(data => console.log("All: " + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }
  addCar(vehicle: IVehicle): Observable<IVehicle> {
    return this.http.post<IVehicle>(this.createCarUrl, vehicle, httpOptions);
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
