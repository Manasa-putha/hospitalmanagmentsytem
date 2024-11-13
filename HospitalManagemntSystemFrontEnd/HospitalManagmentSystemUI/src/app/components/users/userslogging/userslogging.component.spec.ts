import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersloggingComponent } from './userslogging.component';

describe('UsersloggingComponent', () => {
  let component: UsersloggingComponent;
  let fixture: ComponentFixture<UsersloggingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UsersloggingComponent]
    });
    fixture = TestBed.createComponent(UsersloggingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
