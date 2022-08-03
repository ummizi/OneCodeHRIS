import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Address } from 'src/app/shared/address/address.model';
import { AddressService } from 'src/app/shared/address/address.service';
// import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.scss']
})
export class AddressComponent implements OnInit {

  constructor(public service:AddressService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }
  populateForm(selectedRecord:Address){
    this.service.formData = Object.assign({},selectedRecord);
  }

  onDelete(id:Guid){
    if(confirm('Are you sure to delete this record?'))
    {
      this.service.deleteAddress(id)
      .subscribe(
        res=>
        {
          this.service.refreshList();
          // this.toastr.error("Deleted Succesfully",'Address');
        },
        err=>{console.log(err)}
      )
    }
  }
}
