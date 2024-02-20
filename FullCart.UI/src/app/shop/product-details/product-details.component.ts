import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/_models/Product';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit{
  product!: IProduct;
  routeParam: any;

  constructor(private shopService: ShopService,private activatedRoute: ActivatedRoute){
  }

  ngOnInit(): void {
    this.routeParam = this.activatedRoute.snapshot.paramMap.get('id');
    this.loadProduct();    
  }

  loadProduct(){
    this.shopService.getProduct(this.routeParam)
      .subscribe(product =>{
        this.product = product;
      },error => {
        console.log(error);
      });    
  }

}
