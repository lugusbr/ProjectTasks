import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewTasktypeComponent } from './new-tasktype.component';

describe('NewTasktypeComponent', () => {
  let component: NewTasktypeComponent;
  let fixture: ComponentFixture<NewTasktypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewTasktypeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewTasktypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
