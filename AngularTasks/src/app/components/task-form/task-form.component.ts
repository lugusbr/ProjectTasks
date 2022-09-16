import { Component, OnInit, Output, EventEmitter } from '@angular/core';

import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
  FormArray,
} from '@angular/forms';
import { TasksService } from 'src/app/services/tasks/tasks.service';

import { ActivatedRoute } from '@angular/router';

import { Task } from 'src/interfaces/Task';
import { TaskTime } from 'src/interfaces/TaskTime';

import { TaskType } from 'src/interfaces/TaskType';
import { TasktypeService } from 'src/app/services/tasktype/tasktype.service';

import { TasktimeService } from 'src/app/services/tasktime/tasktime.service';


@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css'],
})
export class TaskFormComponent implements OnInit {
  @Output() onSubmit = new EventEmitter<Task>();

  task: Task | null = null;

  taskTypes: TaskType[] = [];

  taskForm!: FormGroup;

  constructor(
    private taskService: TasksService,
    private taskTypeService: TasktypeService,
    private taskTimeService: TasktimeService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.taskTypeService.getAll().subscribe((data) => {
      this.taskTypes = data;
    });

    this.taskForm = this.formBuilder.group({
      id: new FormControl(0),
      name: new FormControl('', [Validators.required]),
      taskTypeId: new FormControl('', [Validators.required]),
      taskTimes: this.formBuilder.array([]),
    });

    var id = Number(this.route.snapshot.paramMap.get('id'));

    if (id != 0) {
      this.taskService.get(id).subscribe((item: Task) => {
        this.task = item;
        if (this.task) {
          this.taskForm.patchValue({
            id: this.task.id,
            name: this.task.name,
            taskTypeId: this.task.taskTypeId,
          });
        }

        this.task.taskTimes?.map((tasktime: TaskTime) => {
          const taskTimeForm = this.formBuilder.group({
            id: tasktime.id,
            taskId: tasktime.taskId,
            startDateTime: tasktime.startDateTime,
            endDateTime: tasktime.endDateTime,
          });

          this.taskTimes.push(taskTimeForm);
        });
      });
    }
  }

  get taskTimes(): FormArray {
    return this.taskForm.get('taskTimes') as FormArray;
  }

  get name() {
    return this.taskForm.get('name')!;
  }

  get taskTypeId() {
    return this.taskForm.get('taskTypeId')!;
  }

  get Id() {
    return this.taskForm.get('id')!;
  }

  newTaskTime(): FormGroup {
    return this.formBuilder.group({
      id: 0,
      taskId: this.Id,
      startDateTime: '',
      endDateTime: '',
    });
  }

  addTaskTimes() {
    this.taskTimes.push(this.newTaskTime());
  }

  removeTaskTime(i: number) {
    console.log(this.taskTimes.at(i).value.id);
    if (this.taskTimes.at(i).value.id != 0)
      this.taskTimeService.removeTaskTime(this.taskTimes.at(i).value.id);
    this.taskTimes.removeAt(i);
    
  }

  submit() {
    console.log(this.taskForm.value);

    if (this.taskForm.invalid) {
      return;
    }

    var taskTimesRequest: TaskTime[] = this.taskTimes.value;

    var taskRequest: Task = {
      id: this.taskForm.value.id,
      name: this.taskForm.value.name,
      taskTypeId: this.taskForm.value.taskTypeId,
      taskTimes: taskTimesRequest,
    };

    // taskRequest.taskTimes?.push(taskTimesRequest);
    console.log(taskRequest);
    console.log(taskTimesRequest);

    //  for (let i = 0; i < this.taskTimes.length; i++) {
    //    const element = this.taskTimes.at(i);
    //    if (element.valid) {
    //       var t: TaskTime = {
    //         id: element.get('id')
    //       }
    //    }
    //  }

    this.onSubmit.emit(taskRequest);
  }
}
