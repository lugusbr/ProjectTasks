import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTasktypeComponent } from './edit-tasktype.component';

describe('EditTasktypeComponent', () => {
  let component: EditTasktypeComponent;
  let fixture: ComponentFixture<EditTasktypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditTasktypeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditTasktypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
