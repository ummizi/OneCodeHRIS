import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ICreateAccount } from '../../create-account.helper';
import { ProfileService } from 'src/app/shared/profile/profile.service';
import { NgForm }   from '@angular/forms';
import { Profile } from 'src/app/shared/profile/profile.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';


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
  @Output() personalData = new EventEmitter<string>();
  private dataURl = 'https://localhost:5001/api/PersonalData';
  name = '';
  @Output() object = new EventEmitter();
  public dataList: Profile[] = [];

  constructor(private fb: FormBuilder, private profileService:ProfileService, private http: HttpClient) {}

  ngOnInit() {
    this.initForm();
    this.updateParentModel({}, true);
  }

  //ADDED
  getData(): void {
    this.http.get(this.dataURl).subscribe((response) => {
      console.log(response);
    });
  }

  sendName() {
    console.log(this.name);
    this.personalData.emit(this.name);
  }

  testFunction(): void {
    this.sendName();
    console.log(this.name);

    console.log('thanks for calling me!');
  }

  onSubmit(f: NgForm) {
    console.log(f.value); // { first: '', last: '' }
    console.log(f.valid); // false
    console.log(f);
    this.object.emit(f);
  }

  // END ADDED

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

  
}
