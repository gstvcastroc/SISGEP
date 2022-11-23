import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

  constructor(private _httpClient: HttpClient, private _modalService: NgbModal) { }

  ngOnInit(): void {
  }

  loadProjects() : Project[] {

    /*this._httpClient.get<Project[]>('https://localhost:5001/api/Project').subscribe(result => { projectsList = result }); Chamada HTTP para preencher a entidade*/

    const projectsList: Project[] = [
      { id: 1, title: 'Alpha', description: 'Mussum Ipsum, cacilds vidis litro abertis.' },
      { id: 2, title: 'Beta', description: 'Mussum Ipsum, cacilds vidis litro abertis.' },
      { id: 3, title: 'Gama', description: 'Mussum Ipsum, cacilds vidis litro abertis.' },
      { id: 4, title: 'Andromeda', description: 'Mussum Ipsum, cacilds vidis litro abertis.' },
      { id: 5, title: 'Orion', description: 'Mussum Ipsum, cacilds vidis litro abertis.' },
      { id: 6, title: 'Marte', description: 'Mussum Ipsum, cacilds vidis litro abertis.' },
      { id: 7, title: 'Saturno', description: 'Mussum Ipsum, cacilds vidis litro abertis.' }
    ];

    return projectsList;
  }

  showDashboard(): void{
    const _modalRef = this._modalService.open(ModalComponent,
      {
        size: 'lg',
        modalDialogClass: 'modal-dialog modal-dialog-centered'
      });

      let urlEmbed: string ='https://datastudio.google.com/embed/reporting/ebd93138-721e-406d-bf69-6d995a6dd63a/page/52A7C';

      _modalRef.componentInstance.url = urlEmbed;
  }

  newProject() : void{

    /*Criar chamada do modal e prencher o dataModal com os dados retornados do HTTP GET*/
    alert('bateu');
  }

  editProject(id : string) : void{

    /*Criar chamada do modal e prencher o dataModal com os dados retornados do HTTP GET*/
    alert('bateu: ' +  id);
  }

  deleteProject(id : string) : void{

    /*Criar chamada do modal e prencher o dataModal com os dados retornados do HTTP GET*/
    alert('bateu: ' +  id);
  }
}

interface Project {
  id: number;
  title: string;
  description: string;
}
