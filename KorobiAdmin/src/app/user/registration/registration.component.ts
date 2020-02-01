import {Component, OnInit} from '@angular/core';
import {UserService} from 'src/app/user.service';
import { CategoryService } from 'src/app/category.service';
import { ServiceGetListService } from 'src/app/service-get-list.service';

import { FormControl } from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  providers: [DatePipe]
})
export class RegistrationComponent implements OnInit {
  categorylist = [];
  subCategorylist=[];
  subSubCategorylist = [];
  writerlist = [];
  publisherlist = [];
  public username: string;
  public responseData1: any;
  public responseData2: any;
  public responseData3: any;
  myControl = new FormControl();
  myDate = new Date();
  public date: string;
  options: string[] = ['One', 'Two', 'Three'];
  filteredOptions: Observable<string[]>;
  constructor(private datePipe: DatePipe,public service: UserService, private category: CategoryService, private servicegetlist: ServiceGetListService)  {
    this.date = this.datePipe.transform(this.myDate, 'yyyy-MM-dd');
  }

  ngOnInit() {
    console.log("i");
    console.log("i");
    this.filteredOptions = this.myControl.valueChanges
    .pipe(
      startWith(''),
      map(value => this._filter(value))
    );

this.category.getCategory().subscribe( res =>{
  this.categorylist = res as []
})
this.category.getSubCategory().subscribe( res =>{
  this.subCategorylist = res as []
})
this.category.getSubSubCategory().subscribe( res =>{
  this.subSubCategorylist = res as []
  
})
this.servicegetlist.getWriterlist().subscribe( res =>{
  this.writerlist = res as []
 
})
this.servicegetlist.getPublisherList().subscribe( res =>{
  this.publisherlist = res as []
})

  }

  onSubmit() {
    this.service.register(this.date).subscribe(
      responseList => {
        this.responseData1 = responseList[0];
        this.responseData2 = responseList[1];
        console.log(this.responseData1);
        console.log(this.responseData2);

          });
      
  }
  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.writerlist.filter(option => option.name.toLowerCase().includes(filterValue));
  }

}
