import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TasktypesComponent } from './tasktypes.component';

describe('TasktypesComponent', () => {
  let component: TasktypesComponent;
  let fixture: ComponentFixture<TasktypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TasktypesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TasktypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
