import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ICreateAccount } from 'src/app/modules/wizards/create-account.helper';
import { ProfileService } from 'src/app/shared/profile/profile.service';
import { NgForm }   from '@angular/forms';
import { Profile } from 'src/app/shared/profile/profile.model';

@Component({
  selector: 'app-step1',
  templateUrl: './step1.component.html', 
  styles: [
  ]
})
export class Step1Component implements OnInit, OnDestroy {
  @Input('updateParentModel') updateParentModel: (
    part: Partial<ICreateAccount>,
    isFormValid: boolean
  ) => void;
  form: FormGroup;
  @Input() defaultValues: Partial<ICreateAccount>;
  private unsubscribe: Subscription[] = [];

  constructor(private fb: FormBuilder, private profileService:ProfileService) {}

  ngOnInit() {
    this.initForm();
    this.updateParentModel({}, true);
  }

  // onContinue(form:NgForm){
  //   if (this.profileService.formData)
  //     this.insertRecord(form);
  //   else
  //    this.updateRecord(form);
  // }

  // insertRecord(form:NgForm){
  //   this.profileService.postProfile().subscribe(
  //     res => {
  //       this.resetForm(form);
  //       this.profileService.refreshList();
  //       // this.toastr.success('Submitted successfully','Payment Detail Register')
  //     },
  //     err => {console.log(err); }
  //   );
  // }
  // updateRecord(form:NgForm){
  //   this.profileService.putProfile().subscribe(
  //     res => {
  //       this.resetForm(form);
  //       this.profileService.refreshList();
  //       // this.toastr.info('Update successfully','Payment Detail Register')
  //     },
  //     err => {console.log(err); }
  //   );
  // }

  // resetForm(form:NgForm){
  //   form.form.reset();
  //   this.profileService.formData = new Profile();
  // }

  initForm() {
    this.form = this.fb.group({
      accountType: [this.defaultValues.accountType, [Validators.required]],
    });

    const formChangesSubscr = this.form.valueChanges.subscribe((val) => {
      this.updateParentModel(val, true);
    });
    this.unsubscribe.push(formChangesSubscr);
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
  }
}
