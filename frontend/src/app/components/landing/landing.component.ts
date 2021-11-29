/**
 * @description The below code is used to display the landing page
 * importing  Component, OnInit  from '@angular/core
 * importing html and css from about landing folder
 */
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
