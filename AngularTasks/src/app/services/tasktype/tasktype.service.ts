import { Injectable } from '@angular/core';
import { TaskType } from 'src/interfaces/TaskType';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TasktypeService {

  private baseApiUrl = environment.baseApiUrl;
  private apiUrl = `${this.baseApiUrl}api/TaskType`;
  constructor(private http: HttpClient) { 

  }


  getAll(): Observable<TaskType[]> {
        return this.http.get<TaskType[]>(this.apiUrl);
  }

  get(id: number): Observable<TaskType> {
     const url = `${this.apiUrl}/${id}`;
     return this.http.get<TaskType>(url);
   }

  newTaskType(newTaskType: TaskType): Observable<TaskType> 
  {
    return this.http.post<TaskType>(this.apiUrl, newTaskType);
  }

  editTaskType(taskType: TaskType): Observable<TaskType> 
  {
     return this.http.put<TaskType>(this.apiUrl, taskType);
  }

  removeTaskType(id: number)
  {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url);
  }
}
