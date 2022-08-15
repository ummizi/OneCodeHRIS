import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Profile } from './profile.model';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http:HttpClient) { }

  readonly baseURL='https://localhost:5001/api/PersonalData';
  formData:Profile = new Profile();
  list:Profile[];

  postProfile()
  {
    return this.http.post(this.baseURL, this.formData);
  }

  putProfile()
  {
    return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData);
  }

  deleteProfile(id:Guid)
  {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  getProfilebyId(id:Guid)
  {
    return this.http.get(`${this.baseURL}/${id}`);
  }

  refreshList()
  {
    this.http.get(this.baseURL)
    .toPromise()
    .then(res=>this.list = res as Profile[]);
  }

}
