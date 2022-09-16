import { Component, OnInit } from '@angular/core';
import { TasktypeService } from 'src/app/services/tasktype/tasktype.service';
import { Router, ActivatedRoute } from '@angular/router';

import { TaskType } from 'src/interfaces/TaskType';

@Component({
  selector: 'app-edit-tasktype',
  templateUrl: './edit-tasktype.component.html',
  styleUrls: ['./edit-tasktype.component.css']
})
export class EditTasktypeComponent implements OnInit {

  btnText: string = 'salvar';


  constructor(
    private taskTypeService: TasktypeService,
    private route: ActivatedRoute,
    private router: Router,
  ) {

   }

  ngOnInit(): void {
  }
  
  async editHandler(tasktype: TaskType){
    
    await this.taskTypeService.editTaskType(tasktype).subscribe();

    this.router.navigate(['tipostarefa']);

  }

}
