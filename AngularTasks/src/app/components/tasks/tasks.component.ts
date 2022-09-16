import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Task } from 'src/interfaces/Task';
import { TasksService } from 'src/app/services/tasks/tasks.service';


@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  tasks: Task[] = []

  constructor(private tasksService: TasksService, private router: Router) { 
    router.events.subscribe(x => {
      this.tasksService.getAll().subscribe((item) => {
        this.tasks = item;
      });
    });
  }

  ngOnInit(): void {
  }


  removeHandler(id: number) {
    if (id) {
      this.tasksService.removeTask(id).subscribe();

      this.tasks = this.tasks.filter((x) => x.id != id);
  
    }
  }

}
