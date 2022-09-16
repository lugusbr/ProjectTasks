import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TasksService } from 'src/app/services/tasks/tasks.service';
import { Task } from 'src/interfaces/Task';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css']
})
export class EditTaskComponent implements OnInit {

  constructor(
    private tasksService: TasksService,
    private router: Router) { }

  ngOnInit(): void {
  }

  createHandler(task: Task){

   /// console.log(task);
    this.tasksService.editTask(task).subscribe();

    this.router.navigate(['tarefas']);

  }

}
