import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserappintmentsComponent } from './userappintments.component';

describe('UserappintmentsComponent', () => {
  let component: UserappintmentsComponent;
  let fixture: ComponentFixture<UserappintmentsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserappintmentsComponent]
    });
    fixture = TestBed.createComponent(UserappintmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
