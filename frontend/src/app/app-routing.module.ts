import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { ForgotpasswordComponent } from './components/forgotpassword/forgotpassword.component'; 
import { LandingComponent } from './components/landing/landing.component';
import { MainComponent } from './components/main/main.component';

const routes: Routes = [
  {path:'',component: LandingComponent},
  {path:'login',component:LoginComponent},
  {path:'signup',component:SignupComponent},
  {path:'forgotpassword',component:ForgotpasswordComponent},
  {path:'main',component:MainComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
