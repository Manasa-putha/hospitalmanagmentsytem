import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMedicalRecordDialogComponent } from './edit-medical-record-dialog.component';

describe('EditMedicalRecordDialogComponent', () => {
  let component: EditMedicalRecordDialogComponent;
  let fixture: ComponentFixture<EditMedicalRecordDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditMedicalRecordDialogComponent]
    });
    fixture = TestBed.createComponent(EditMedicalRecordDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
