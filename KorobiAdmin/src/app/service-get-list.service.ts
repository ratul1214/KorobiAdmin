import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ServiceGetListService {
  readonly BaseURI = 'https://localhost:44399/api';
  constructor(private http: HttpClient) { }
  getWriterlist()
  {
return this.http.get(this.BaseURI+"/WriterLists");
  }
  getPublisherList()
  {
 var v=this.http.get(this.BaseURI+"/PublisherLists");
 console.log(v);
 return v;
  }
}
