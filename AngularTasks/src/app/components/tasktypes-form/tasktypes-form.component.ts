import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { FormGroup, FormControl, Validators } from '@angular/forms';
import {  ActivatedRoute } from '@angular/router';

import { TaskType } from 'src/interfaces/TaskType';
import { TasktypeService } from 'src/app/services/tasktype/tasktype.service';

@Component({
  selector: 'app-tasktypes-form',
  templateUrl: './tasktypes-form.component.html',
  styleUrls: ['./tasktypes-form.component.css']
})
export class TasktypesFormComponent implements OnInit {

  @Input() btnText: string = '';

  taskType: TaskType | null = null;

  @Output() onSubmit = new EventEmitter<TaskType>();

  taskTypeForm!: FormGroup

  constructor(
    private taskTypeService: TasktypeService,
    private route: ActivatedRoute,
     ) { }

  ngOnInit(): void {

    this.taskTypeForm = new FormGroup({
            id: new FormControl(0),
            name: new FormControl('', [Validators.required]),
      });

    const id = Number(this.route.snapshot.paramMap.get('id'));
    
    if (id != 0)
    {
      this.taskTypeService.get(id).subscribe((item: TaskType) => {
          this.taskType = item;
            if (this.taskType)
            {
              this.taskTypeForm.setValue({
                id: this.taskType.id,
                name: this.taskType.name
              });
            }
        });
    }

  }

  get name() {
    return this.taskTypeForm.get('name')!;
  }

  submit() {
    if (this.taskTypeForm.invalid) {
      return;
    }
  
    this.onSubmit.emit(this.taskTypeForm.value);
  }
}
