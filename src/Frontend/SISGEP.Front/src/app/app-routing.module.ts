import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { MasterComponent } from './pages/master/master.component';
import { PersonComponent } from './pages/person/person.component';
import { ProjectsComponent } from './pages/projects/projects.component';
import { QuestionaryComponent } from './pages/questionary/questionary.component';

const routes: Routes = [
  {
    path: '',
    component: MasterComponent,
    children: [
      { path: '', component: HomeComponent },
      { path: 'projects', component: ProjectsComponent },
      { path: 'questionary', component: QuestionaryComponent },
      { path: 'person', component: PersonComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
