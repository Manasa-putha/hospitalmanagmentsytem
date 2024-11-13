import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPatientDialogComponentComponent } from './edit-patient-dialog-component.component';

describe('EditPatientDialogComponentComponent', () => {
  let component: EditPatientDialogComponentComponent;
  let fixture: ComponentFixture<EditPatientDialogComponentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditPatientDialogComponentComponent]
    });
    fixture = TestBed.createComponent(EditPatientDialogComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
