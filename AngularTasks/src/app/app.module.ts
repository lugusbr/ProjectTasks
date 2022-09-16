import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './components/home/home.component';

import { NewTasktypeComponent } from './components/new-tasktype/new-tasktype.component';
import { TasksComponent } from './components/tasks/tasks.component';
import { TasktypesFormComponent } from './components/tasktypes-form/tasktypes-form.component';
import { TasktypesComponent } from './components/tasktypes/tasktypes.component';
import { EditTasktypeComponent } from './components/edit-tasktype/edit-tasktype.component';
import { NewTaskComponent } from './components/new-task/new-task.component';
import { TaskFormComponent } from './components/task-form/task-form.component';
import { EditTaskComponent } from './components/edit-task/edit-task.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    NewTasktypeComponent,
    TasksComponent,
    TasktypesFormComponent,
    TasktypesComponent,
    EditTasktypeComponent,
    NewTaskComponent,
    TaskFormComponent,
    EditTaskComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
