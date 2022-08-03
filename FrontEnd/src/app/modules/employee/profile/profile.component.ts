import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { ToastrService } from 'ngx-toastr';
import { Profile } from 'src/app/shared/profile/profile.model';
import { ProfileService } from 'src/app/shared/profile/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: []
})
export class ProfileComponent implements OnInit {

  constructor(public service:ProfileService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }
  populateForm(selectedRecord:Profile)
  {
    this.service.formData = Object.assign({}, selectedRecord);
  }
  onDelete(id:Guid)
  {
    if(confirm('Are you sure to delete this record?'))
    {
      this.service.deleteProfile(id)
      .subscribe(
        res=>
        {
          this.service.refreshList();
          // this.toastr.error("Deleted Successfully", 'Profile');
        },
        err=>{console.log(err)
        }
      )
    }
  }
}
