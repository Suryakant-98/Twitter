import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { pipe } from 'rxjs';
import {map} from 'rxjs/operators'
@Injectable({
  providedIn: 'root'
})
export class ApiService{

  readonly APIUrl = "http://localhost:47667/api/Travel/Register";

  constructor(private _http : HttpClient) { }

 
  Signup(empObj : any){
    console.log("empobj.....",empObj);
    //return this._http.post<any>(this.loginAPIUrl+"signup",empObj)
    return this._http.post<any>(this.APIUrl ,empObj)
  }
  Login(empObj:any){
    return this._http.get<any>(this.APIUrl,empObj)
  }
  Password(empObj:any){
    return this._http.get<any>(this.APIUrl,empObj)

  }
  
}