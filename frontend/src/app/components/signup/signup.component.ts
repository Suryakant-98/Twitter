/**
 * @description The below code is used to signup
 * importing  Component, OnInit  from '@angular/core'
 * importing html and css from about signup folder
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { UserModel } from '../shared/model/user.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
/**
 * @description : created a class component with the name Signup Component  
 * validates the information given by the user
 * @params : {string}
 * @return : non
 */
export class SignupComponent implements OnInit {
  public data = {
  username: '',
  email:  '',
  password: '',
  confirmPassword: '',
}
  valid = {
    username: true,
    email: true,
    password: true,
    confirmPassword: true,
  };
  public registerObj = new UserModel();
  constructor( private http : HttpClient,private router : Router, private api: ApiService) { }


 

  ngOnInit(): void {}
   //validation part
  validate(type: string): void {
    const usernamePattern = /^[\w-.]*$/;
    const emailPattern = /\S+@\S+\.\S+/;

    if (type === 'username') {
      if (this.data.username.length < 5) {
        this.valid.username = false;
      } else {
        this.valid.username = usernamePattern.test(this.data.username);
      }
    } else if (type === 'email') {
      this.valid.email = emailPattern.test(this.data.email);
    } else if (type === ('confirmPassword' || 'password')) {
      if (this.data.password !== this.data.confirmPassword) {
        this.valid.password = false;
      } else {
        this.valid.password = true;
      }  
    }
  
      
  
  }
//onkey function which is used to connect to the html file
  onkey(event: any, type: string) {
    if (type === 'username') {
      this.data.username = event.target.value;
    } else if (type === 'email') {
      this.data.email = event.target.value;
    } else if (type === 'password') {
      this.data.password = event.target.value;
    } else if (type === 'confirmPassword') {
      this.data.confirmPassword = event.target.value;
    }
    this.validate(type);
  }
  Signup() {
    const formData = new FormData();
    formData.append("UserName",this.data.username)
    formData.append("EmailId",this.data.email)
    formData.append("Password",this.data.password)
    formData.append("ConfirmPassword",this.data.confirmPassword)
   
 
 
    console.log(this.registerObj)
    this.api.Signup(formData)
    .subscribe(res =>{
      alert("success");
    })
   }

}
