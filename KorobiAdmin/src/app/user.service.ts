import {Injectable} from '@angular/core';

import {FormBuilder, Validators, FormGroup} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import { forkJoin } from 'rxjs';
import * as uuid from 'uuid';

@Injectable({
  providedIn: 'root',
  
})

export class UserService {
  myDate = new Date();
  constructor(private fb: FormBuilder, private http: HttpClient) {
    
  }

  readonly BaseURI = 'https://localhost:44399/api';
  formModel = this.fb.group({

    SKU: ['', Validators.required],
    title: ['', Validators.email],
    brand: [''],
    producer: [''],
    shortDetails: [''],
    description: [''],
    catagory_id: [null],
    subCategory_id: [null],
    subSubCategory_id: [null],
    product_status: [''],
    updated: [''],
    product_Currency: [''],
    price_id: [null],
    stock: [null],
    images: [''],
    created: ['']

  });

  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    // passwordMismatch
    // confirmPswrdCtrl.errors={passwordMismatch:true}
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value) {
        confirmPswrdCtrl.setErrors({passwordMismatch: true});
      } else {
        confirmPswrdCtrl.setErrors(null);
      }
    }
  }

  register( date:string) {
    const productid = uuid.v4();
    const priceId = uuid.v4();
    let random = Math.floor(Math.random() * (999999 - 100000)) + 100000;
    // tslint:disable-next-line:prefer-const
    let body = {
      id: 54545,
      SKU: this.formModel.value.SKU,
      title: this.formModel.value.title,
      brand: this.formModel.value.myControl,
      producer: this.formModel.value.producer,
      shortDetails: this.formModel.value.shortDetails,
      description: this.formModel.value.description ,
      catagory_id: this.formModel.value.catagory_id ,
      subCategory_id: this.formModel.value.subCategory_id ,
      subSubCategory_id: this.formModel.value.subSubCategory_id ,
      product_status: this.formModel.value.product_status ,
      updated: date,
      product_Currency: this.formModel.value.product_Currency ,
      price_id: this.formModel.value.price_id ,
      stock: this.formModel.value.stock ,
      images: this.formModel.value.images ,
      created: date ,
      
      
    };
    let body_price = {
      
      product_id: 5454 , 
      price_type: 1,
      active_flag: "active",
      start_date: date,
      end_date:date,
      price :this.formModel.value.price_id ,
      created_by :1 ,
      creation_date:date,
      last_updated_by : 1,
      last_update_date :date,
      
      
    };
    
    
    let response1 = this.http.post(this.BaseURI + '/Products', body);
    let response2 = this.http.post(this.BaseURI + '/Product_Price', body_price);
   
    // Observable.forkJoin (RxJS 5) changes to just forkJoin() in RxJS 6
    return forkJoin([response1, response2]);

    
  }
}
