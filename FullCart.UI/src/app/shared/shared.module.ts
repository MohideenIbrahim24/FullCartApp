import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagingHeaderComponent } from './_components/paging-header/paging-header.component';
import { PagerComponent } from './_components/pager/pager.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';




@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot()
  ],  
  exports: [
    PagingHeaderComponent,
    PagerComponent    
  ]

})
export class SharedModule { }