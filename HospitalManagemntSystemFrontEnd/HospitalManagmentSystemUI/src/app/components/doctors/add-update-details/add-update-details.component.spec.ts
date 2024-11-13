import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdateDetailsComponent } from './add-update-details.component';

describe('AddUpdateDetailsComponent', () => {
  let component: AddUpdateDetailsComponent;
  let fixture: ComponentFixture<AddUpdateDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddUpdateDetailsComponent]
    });
    fixture = TestBed.createComponent(AddUpdateDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
