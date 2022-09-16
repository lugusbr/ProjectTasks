import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TasktypesFormComponent } from './tasktypes-form.component';

describe('TasktypesFormComponent', () => {
  let component: TasktypesFormComponent;
  let fixture: ComponentFixture<TasktypesFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TasktypesFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TasktypesFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
