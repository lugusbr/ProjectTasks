import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Task } from 'src/interfaces/Task';
import { TaskRequest } from 'src/interfaces/TaskRequest';

@Injectable({
  providedIn: 'root',
})
export class TasksService {
  private baseApiUrl = environment.baseApiUrl;
  private apiUrl = `${this.baseApiUrl}api/Task`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Task[]> {
    return this.http.get<Task[]>(this.apiUrl);
  }

  get(id: number): Observable<Task> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Task>(url);
  }

  newTask(newTask: Task): Observable<Task> {
    return this.http.post<Task>(this.apiUrl, newTask);
  }

  editTask(task: Task): Observable<Task> {
    return this.http.put<Task>(this.apiUrl, task);
  }

  removeTask(id: number) {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url);
  }
}
