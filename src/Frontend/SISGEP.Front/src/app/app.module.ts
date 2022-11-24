import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

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
    DeleteProjectComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
