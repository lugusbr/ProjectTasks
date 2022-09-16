import { Task } from "./Task";

export interface TaskTime {
    id?: number;
    task: Task;
    taskId: number;
    startDateTime: string;
    endDateTime: string;
  }
  