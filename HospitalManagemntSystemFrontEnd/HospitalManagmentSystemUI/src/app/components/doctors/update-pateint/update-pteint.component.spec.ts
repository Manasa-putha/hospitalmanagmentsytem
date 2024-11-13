import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePteintComponent } from './update-pteint.component';

describe('UpdatePteintComponent', () => {
  let component: UpdatePteintComponent;
  let fixture: ComponentFixture<UpdatePteintComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdatePteintComponent]
    });
    fixture = TestBed.createComponent(UpdatePteintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
