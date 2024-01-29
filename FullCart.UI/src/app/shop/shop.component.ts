import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand, ICategory, IProduct } from '../shared/_models/Product';
import { ShopService } from './shop.service';
import { ShopParams } from '../shared/_models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  @ViewChild('search',{static:false}) searchTerm!: ElementRef;
  products: IProduct[] | null = [];
  brands: IBrand[] = [];
  categories: ICategory[] = [];
  brandIdSelected: string = "";
  categoryIdSelected: string = "";
  sortSelected = 'name';
  sortOptions = [
    {name: 'Alphabetical' ,value: 'name'},
    {name: 'Price: Low to High',value: 'productPriceAsc'},
    {name: 'Price: High to Low',value: 'productPriceDesc'}
  ];
  shopParams = new ShopParams();
  totalCount: number = 0;

  constructor(private shopService: ShopService) { }


  ngOnInit(): void {
    this.getAllProducts();
    this.getAllBrands();
    this.getAllCategories();
  }

  getAllProducts(): void {
    this.shopService.getAllProducts(this.shopParams).subscribe((response: any) => {
      this.products = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  getAllBrands(): void {
    this.shopService.getAllBrands().subscribe((response: any) => {
      this.brands = [{id: "",name: "All"},...response];
    }, error => {
      console.log(error);
    });
  }

  getAllCategories(): void {
    this.shopService.getAllCategories().subscribe((response: any) => {
      this.categories = [{id: "",categoryName: "All"},...response];
    }, error => {
      console.log(error);
    });
  }

  onBrandSelected(brandId: string): void{
    this.shopParams.brandId = brandId;
    this.getAllProducts();
  }

  onCategorySelected(categoryId: string): void{
    this.shopParams.categoryId = categoryId;
    this.getAllProducts();
  }

  onSortSelected(event: Event): void{
    this.shopParams.sort = (event.target as HTMLSelectElement).value;
    this.getAllProducts();
  }

  onPageChanged(event: any): void{
    this.shopParams.pageNumber = event;
    this.getAllProducts();
  }

  onSearch(): void{
    this.shopParams.search = this.searchTerm?.nativeElement.value;
    this.getAllProducts();
  }

  onReset(): void{
    this.searchTerm.nativeElement.value = "";
  }
}
