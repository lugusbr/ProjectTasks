import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TasksService } from 'src/app/services/tasks/tasks.service';
import { Task } from 'src/interfaces/Task';

@Component({
  selector: 'app-new-task',
  templateUrl: './new-task.component.html',
  styleUrls: ['./new-task.component.css']
})
export class NewTaskComponent implements OnInit {

  constructor(
    private tasksService: TasksService,
    private router: Router
    ) { }

  ngOnInit(): void {
  }

  createHandler(task: Task){

    console.log(task);
    this.tasksService.newTask(task).subscribe();

    this.router.navigate(['tarefas']);

  }

}
