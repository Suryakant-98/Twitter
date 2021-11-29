/**
 * @description The below code is used to change the password
 * importing  Component, OnInit  from '@angular/core'
 * importing Swal from 'sweetalert2'
 * importing html and css from about forgotpassword folder
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { UserModel } from '../shared/model/user.model';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-forgotpassword',
  templateUrl: './forgotpassword.component.html',
  styleUrls: ['./forgotpassword.component.css']
})

/**
 * @description : created a class component with the name ForgotpasswordComponent  
 * @params : {string}
 * @returns : non
 */
export class ForgotpasswordComponent implements OnInit {
  public data = {
  email: "",
  password: "",
  }

  valid = {
    email: true,
  }

  public passwordObj = new UserModel();
  constructor(private http: HttpClient, private router: Router, private api: ApiService) { }


  

  ngOnInit(): void {
  }
  validate(type: string): void {
    const emailPattern = /\S+@\S+\.\S+/;

    if (type === 'email') {
      this.valid.email = emailPattern.test(this.data.email);
    }
  }

  //onkey function
  onkey(event: any, type: string) {
    if (type === 'email') {
      this.data.email = event.target.value;
    }
    this.validate(type)
  }
  Password() {
    const formData = new FormData();
    formData.append("Emailid",this.data.email)
    formData.append("CreatePassword",this.data.password)

    
    console.log(this.passwordObj)
    this.api.Password(formData)
      .subscribe(res => {
        alert("success");
      })
  }
  // successNotification() {
  //   Swal.fire('Password has been successfully updated', 'We have been informed!', 'success')
  // }
}



