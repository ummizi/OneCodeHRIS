import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Address } from './address.model';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http:HttpClient) { }

  readonly baseURL = 'https://localhost:5001/api/Address'
  formData:Address = new Address();
  list : Address[];

  postAddress(){
    return this.http.post(this.baseURL, this.formData);
  }

  putAddress(){
    return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData);
  }

  deleteAddress(id:Guid){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseURL)
    .toPromise()
    .then(res=>this.list = res as Address[]);
  }
}
