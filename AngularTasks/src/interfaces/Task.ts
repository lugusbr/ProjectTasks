import { TaskType } from "./TaskType";
import { TaskTime } from "./TaskTime";

export interface Task {
    id: number;
    name: string;
    taskTypeId: number;
    taskType?: TaskType;
    taskTimes?: TaskTime[]

  }
  