import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FamilyDataComponent } from './family-data.component';

describe('FamilyDataComponent', () => {
  let component: FamilyDataComponent;
  let fixture: ComponentFixture<FamilyDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FamilyDataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FamilyDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
