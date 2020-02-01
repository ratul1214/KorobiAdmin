import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  readonly BaseURI = 'https://localhost:44399/api';
  constructor(private http: HttpClient) {  }
  getCategory()
  {
return this.http.get(this.BaseURI+"/Product_Category");
  }
  getSubCategory()
  {
return this.http.get(this.BaseURI+"/Product_sub_Category");
  }
  getSubSubCategory()
  {
return this.http.get(this.BaseURI+"/Product_subSubCategory");
  }
}
