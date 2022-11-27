import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';
import { CreateProjectComponent } from './create/create-project/create-project.component';
import { Project } from 'src/app/interface/project-interface';
import { AlterProjectComponent } from './alter/alter-project/alter-project.component';
import { DeleteProjectComponent } from './delete/delete-project/delete-project.component';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

  constructor(private _httpClient: HttpClient, private _modalService: NgbModal) { }

  ngOnInit(): void {
  }

  _httpRequestUrl = 'https://localhost:5001/api/';

  loadProjects() : Observable<Project[]> {

    /*this._httpClient.get<Project[]>('https://localhost:5001/api/Project').subscribe(result => { projectsList = result }); Chamada HTTP para preencher a entidade*/

    /*let projectsList: Project[] = [
      { id: 1, title: 'Alpha', description: 'Mussum Ipsum, cacilds vidis litro abertis.' },
      { id: 2, title: 'Beta', description: 'Mussum Ipsum, cacilds vidis litro abertis.' },
      { id: 3, title: 'Gama', description: 'Mussum Ipsum, cacilds vidis litro abertis.' },
      { id: 4, title: 'Andromeda', description: 'Mussum Ipsum, cacilds vidis litro abertis.' },
      { id: 5, title: 'Orion', description: 'Mussum Ipsum, cacilds vidis litro abertis.' },
      { id: 6, title: 'Marte', description: 'Mussum Ipsum, cacilds vidis litro abertis.' },
      { id: 7, title: 'Saturno', description: 'Mussum Ipsum, cacilds vidis litro abertis.' }
    ];*/

    return this._httpClient.get<Project[]>(this._httpRequestUrl + 'Project');
  }

  showDashboard(): void{
    let _modalRef = this._modalService.open(ModalComponent,
      {
        size: 'lg',
        modalDialogClass: 'modal-dialog modal-dialog-centered'
      });

      let urlEmbed: string ='https://datastudio.google.com/embed/reporting/ebd93138-721e-406d-bf69-6d995a6dd63a/page/52A7C';

      _modalRef.componentInstance.url = urlEmbed;
  }

  newProject() : void{
    this._modalService.open(CreateProjectComponent,
      {
        size: 'lg',
        modalDialogClass: 'modal-dialog modal-dialog-centered'
      });
  }

  editProject(ProjectId : Guid) : void{
    let _modalRef = this._modalService.open(AlterProjectComponent,
      {
        size: 'lg',
        modalDialogClass: 'modal-dialog modal-dialog-centered'
      });
  }

  deleteProject(ProjectId : Guid) : void{
    let _modalRef = this._modalService.open(DeleteProjectComponent,
      {
        size: 'lg',
        modalDialogClass: 'modal-dialog modal-dialog-centered'
      });
  }
}
