import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { TaskTime } from 'src/interfaces/TaskTime';

@Injectable({
  providedIn: 'root'
})
export class TasktimeService {

  private baseApiUrl = environment.baseApiUrl;
  private apiUrl = `${this.baseApiUrl}api/TaskTime`;

  constructor(private http: HttpClient) {}

  newTaskTime(newTaskTime: TaskTime): Observable<TaskTime> {
    return this.http.post<TaskTime>(this.apiUrl, newTaskTime);
  }

  removeTaskTime(id: number) {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url).subscribe();
  }
}
