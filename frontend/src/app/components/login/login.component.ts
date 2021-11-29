/**
 * @description The below code is used to display the login page
 * importing  Component, OnInit  from '@angular/core
 * importing html and css from login folder
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { UserModel } from '../shared/model/user.model';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

/**
 * @description created a class component with the name LoginComponent 
 * validation for the email inside the class component
 * @params {string}
 * @Return non
 */

export class LoginComponent implements OnInit {
  public data = {
  email: "",
  password: "",
  }

  valid = {
  email : true,
  password: true,
  }
  public loginObj = new UserModel();
  constructor(private http: HttpClient, private router: Router, private api: ApiService) { }



  ngOnInit(): void {
  }
  //validation part
  validate(type: string): void {
    const emailPattern = /\S+@\S+\.\S+/;
    if (type === 'email') {
      this.valid.email = emailPattern.test(this.data.email);
    } 
  }

  //onkey function
    onkey(event:any , type:string){
      if( type === "email"){
        this.data.email = event.target.value;
      }
      this.validate(type)
    }
}
