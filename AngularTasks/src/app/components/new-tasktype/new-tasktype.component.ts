import { Component, OnInit } from '@angular/core';

import { TasktypeService } from 'src/app/services/tasktype/tasktype.service';

import { TaskType } from 'src/interfaces/TaskType';

import { Router } from '@angular/router';

@Component({
  selector: 'app-new-tasktype',
  templateUrl: './new-tasktype.component.html',
  styleUrls: ['./new-tasktype.component.css']
})
export class NewTasktypeComponent implements OnInit {

  btnText: string = 'Salvar';

  constructor(
    private taskTypeService: TasktypeService,
    private router: Router,
  ) { }

  ngOnInit(): void {}

 createHandler(tasktype: TaskType){
    console.log(tasktype)

    this.taskTypeService.newTaskType(tasktype).subscribe();

    this.router.navigate(['tipostarefa']);

  }

}
