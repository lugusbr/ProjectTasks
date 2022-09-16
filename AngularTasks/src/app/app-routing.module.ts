import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { TasksComponent } from './components/tasks/tasks.component';
import { NewTasktypeComponent } from './components/new-tasktype/new-tasktype.component';
import { TasktypesComponent } from './components/tasktypes/tasktypes.component';
import { EditTasktypeComponent } from './components/edit-tasktype/edit-tasktype.component';
import { NewTaskComponent } from './components/new-task/new-task.component';
import { EditTaskComponent } from './components/edit-task/edit-task.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'tarefas', component: TasksComponent},
  {path: 'tarefas/novo', component: NewTaskComponent},
  {path: 'tarefas/editar/:id', component: EditTaskComponent},
  {path: 'tipostarefa', component: TasktypesComponent},
  {path: 'tipostarefa/novo', component: NewTasktypeComponent},
  { path: 'tipostarefa/editar/:id', component: EditTasktypeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
