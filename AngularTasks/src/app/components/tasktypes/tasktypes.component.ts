import { Component, OnInit } from '@angular/core';

import { TaskType } from 'src/interfaces/TaskType';

import { TasktypeService } from 'src/app/services/tasktype/tasktype.service';

import { Router } from '@angular/router';

@Component({
  selector: 'app-tasktypes',
  templateUrl: './tasktypes.component.html',
  styleUrls: ['./tasktypes.component.css']
})
export class TasktypesComponent implements OnInit {

  taskTypes: TaskType[] =[];

  constructor(private taskTypeService: TasktypeService, private router: Router) { 
    router.events.subscribe(x => {
      this.taskTypeService.getAll().subscribe((item) => {
        this.taskTypes = item;
      });
    });
  }


  ngOnInit(): void {
  } 

  async removeHandler(id: number) {
    if (id) {
      await this.taskTypeService.removeTaskType(id).subscribe();

      this.taskTypes = this.taskTypes.filter((x) => x.id != id);
  
    }
  }

}
