import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

import { IProduct } from './_models/Product';
import { IPagination } from './_models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'FullCart.UI';
  products: IProduct[] = [];

  constructor(private http: HttpClient){  }

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/Products').subscribe((response: any) => {
      console.log(response);
      this.products = response;
    },error => {
      console.log(error);
    })
  }
  
}
