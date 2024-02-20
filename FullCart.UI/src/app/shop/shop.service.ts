import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environments } from 'src/environments/environments.development';
import { IBrand, ICategory, IProduct } from '../shared/_models/Product';
import { IPagination } from '../shared/_models/pagination';
import { Observable, delay, map } from 'rxjs';
import { ShopParams } from '../shared/_models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = environments.apiUrl;
  products: IProduct[] = [];

  constructor(private http: HttpClient) { }

  getAllProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if(shopParams.brandId){
      params = params.append('brandId',shopParams.brandId);
    }

    if(shopParams.categoryId){
      params = params.append('categoryId',shopParams.categoryId);
    }

    if(shopParams.search){
      params = params.append('search',shopParams.search);
    }

    params = params.append('sort',shopParams.sort);
    params = params.append('pageIndex',shopParams.pageNumber.toString());
    params = params.append('pageSize',shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products',{observe: 'response',params})
    .pipe(
      // delay(1000),
      map(response => {
        return response.body;
      })
    );
  }

  getProduct(id: string){
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }

  getAllBrands(): Observable<IBrand[]> {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getAllCategories(): Observable<ICategory[]> {
    return this.http.get<ICategory[]>(this.baseUrl + 'products/categories');
  }
}
