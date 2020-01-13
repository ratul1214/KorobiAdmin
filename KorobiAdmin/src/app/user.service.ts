import {Injectable} from '@angular/core';

import {FormBuilder, Validators, FormGroup} from '@angular/forms';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

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
    catagory_id: [null,],
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

  register() {
    // tslint:disable-next-line:prefer-const
    let body = {
      SKU: this.formModel.value.SKU,
      title: this.formModel.value.title,
      brand: this.formModel.value.brand,
      producer: this.formModel.value.producer,
      shortDetails: this.formModel.value.shortDetails,
      description: this.formModel.value.description ,
      catagory_id: this.formModel.value.catagory_id ,
      subCategory_id: this.formModel.value.subCategory_id ,
      subSubCategory_id: this.formModel.value.subSubCategory_id ,
      product_status: this.formModel.value.product_status ,
      updated: this.formModel.value.updated ,
      product_Currency: this.formModel.value.product_Currency ,
      price_id: this.formModel.value.price_id ,
      stock: this.formModel.value.stock ,
      images: this.formModel.value.images ,
      created: this.formModel.value.created ,
      

    };
    return this.http.post(this.BaseURI + '/Products', body);
  }
}
