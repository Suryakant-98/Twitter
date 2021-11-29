/**
 * @description The below code is used to display the tweet
 * importing  Component, OnInit  from '@angular/core'
 * importing Swal from 'sweetalert2'
 * importing html and css from about main folder
 */
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
/**
 * @description created a class component with the name MainComponent 
 */
export class MainComponent implements OnInit {
  

  constructor() { }

  ngOnInit(): void {
  }


}
