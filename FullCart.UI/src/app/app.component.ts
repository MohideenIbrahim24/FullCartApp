import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { IProduct } from './shared/_models/Product';
import { IPagination } from './shared/_models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'FullCart.UI';
  

  constructor() { }

  ngOnInit(): void {    
  }
}
