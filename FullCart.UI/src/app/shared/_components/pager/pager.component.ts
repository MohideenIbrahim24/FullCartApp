import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.css']
})
export class PagerComponent implements OnInit{
  @Input() totalCount: number = 0;
  @Input() pageSize: number = 0;
  @Output() pageChanged = new EventEmitter<number>();


  constructor(){
  }

  ngOnInit(): void {
  }

  onPagerChange(event: any){
    this.pageChanged.emit(event.page);    
  }

}
