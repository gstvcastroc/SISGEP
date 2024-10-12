import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { ProjectsComponent } from './pages/projects/projects.component';
import { MasterComponent } from './pages/master/master.component';
import { QuestionaryComponent } from './pages/questionary/questionary.component';
import { ModalComponent } from './pages/modal/modal.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SafePipe } from './pipes/safe.pipe';
import { CreateProjectComponent } from './pages/projects/create/create-project/create-project.component';
import { AlterProjectComponent } from './pages/projects/alter/alter-project/alter-project.component';
import { DeleteProjectComponent } from './pages/projects/delete/delete-project/delete-project.component';
import { CreateQuestionaryComponent } from './pages/questionary/create/create-questionary/create-questionary.component';
import { AlterQuestionaryComponent } from './pages/questionary/alter/alter-questionary/alter-questionary.component';
import { DeleteQuestionaryComponent } from './pages/questionary/delete/delete-questionary/delete-questionary.component';
import { PersonComponent } from './pages/person/person.component';
import { CreatePersonComponent } from './pages/person/create/create-person/create-person.component';
import { AlterPersonComponent } from './pages/person/alter/alter-person/alter-person.component';
import { DeletePersonComponent } from './pages/person/delete/delete-person/delete-person.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProjectsComponent,
    MasterComponent,
    QuestionaryComponent,
    ModalComponent,
    SafePipe,
    CreateProjectComponent,
    AlterProjectComponent,
    DeleteProjectComponent,
    CreateQuestionaryComponent,
    AlterQuestionaryComponent,
    DeleteQuestionaryComponent,
    PersonComponent,
    CreatePersonComponent,
    AlterPersonComponent,
    DeletePersonComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, NgbModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
